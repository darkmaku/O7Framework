// Created by Felix A. Bueno in 29/09/2016

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Angkor.O7Framework.Common.Validator;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Data.Validator;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Angkor.O7Framework.Data
{
    public partial class O7DbAccess
    {
        private readonly OracleConnection _connection;

        [ContractInvariantMethod]
        private void connection_invariant()
        {
            Contract.Invariant(O7DbValidator.ConnectionIsOpened(_connection));
        }

        public static O7DbAccess Make(string connection)
            => new O7DbAccess(connection);

        protected O7DbAccess(string connection)
        {
            Contract.Requires(O7DbValidator.ValidConnection(connection));
            _connection = new OracleConnection(connection);
            _connection.Open();
        }

        ~O7DbAccess()
        {
            _connection.Dispose();
        }
        
        public TResult ExecuteFunction<TResult>(string name) 
            => ExecuteFunction<TResult>(name, O7DbParameterCollection.Make);

        public TResult ExecuteFunction<TResult>(string name, O7DbParameterCollection parametersCollection)
        {
            Contract.Requires(ContractValidator.StringIsNotNullOrEmpty(name) && parametersCollection != null);
            using (var command = _connection.CreateCommand())
            {
                set_command(command, name, parametersCollection.DbParameters, get_oracle_type(typeof(TResult)));
                command.ExecuteNonQuery();
                if (typeof(TResult) == typeof(string))
                {
                    var result = (OracleString)get_last_value(command);
                    return (TResult)(object)result.Value;
                }
                if (typeof(TResult) == typeof(int))
                {
                    var result = (OracleDecimal)get_last_value(command);
                    return (TResult)(object)Convert.ToInt32(result.Value);
                }                
                return (TResult)get_last_value(command);
            }
        }

        public List<TResult> ExecuteFunction<TResult>(string name, Type mapperType)
            => ExecuteFunction<TResult>(name, O7DbParameterCollection.Make, mapperType);

        public List<TResult> ExecuteFunction<TResult>(string name, O7DbParameterCollection parametersCollection, Type mapperType)            
        {
            Contract.Requires(ContractValidator.StringIsNotNullOrEmpty(name) && parametersCollection != null && mapperType != null);
            var result = new List<TResult>();
            using (var command = _connection.CreateCommand())
            {
                set_command(command, name, parametersCollection.DbParameters, OracleDbType.RefCursor);
                command.ExecuteNonQuery();
                var reader = get_reader(get_last_value(command));                
                while (reader.Read())
                {
                    var mapper = make_mapper_instance<TResult>(mapperType);
                    mapper.SetSource(make_instance_o7row(reader));
                    result.Add(mapper.MapTarget());
                }                
            }
            return result;
        }        
    }
}