// Created by Felix A. Bueno in 29/09/2016

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using Angkor.O7Framework.Data.Common;
using Angkor.O7Framework.Data.Utility;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Angkor.O7Framework.Data
{
    public partial class O7DataAccess : IDisposable
    {
        private readonly OracleConnection _connection;
        
        public O7DataAccess(string connection)
        {
            O7DataBaseValidator.ValidConnection(connection);
            Contract.Ensures(_connection.State == ConnectionState.Open);
            _connection = new OracleConnection(connection);
            _connection.Open();
           
        }

        public void Dispose()
        {
            Contract.Requires(_connection.State == ConnectionState.Open);
            Contract.Ensures(_connection.State == ConnectionState.Closed);

            _connection.Dispose();
        }

        public TResult ExecuteFunction<TResult>(string name) => ExecuteFunction<TResult>(name, O7DbParameterCollection.Make);

        public TResult ExecuteFunction<TResult>(string name, O7DbParameterCollection parametersCollection)
        {
            Contract.Requires(!string.IsNullOrEmpty(name) && parametersCollection != null && this._connection.State == ConnectionState.Open);
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

        public List<TResult> ExecuteFunction<TResult>(string name, Type mapperType) where TResult : O7Entity
            => ExecuteFunction<TResult>(name, O7DbParameterCollection.Make, mapperType);

        public List<TResult> ExecuteFunction<TResult>(string name, O7DbParameterCollection parametersCollection, Type mapperType)
            where TResult : O7Entity
        {
            Contract.Requires(!string.IsNullOrEmpty(name) && parametersCollection != null && mapperType != null && this._connection.State == ConnectionState.Open);

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