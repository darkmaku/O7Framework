﻿// Created by Felix A. Bueno in 29/09/2016

using System;
using System.Collections.Generic;
using Angkor.O7Framework.Data.Common;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Framework.Data
{
    public partial class O7DataAccess : IDisposable
    {
        private readonly OracleConnection _connection;

        public O7DataAccess(string connection)
        {
            _connection = new OracleConnection(connection);
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public TResult ExecuteFunction<TResult>(string name) => ExecuteFunction<TResult>(name, new O7Parameter());

        public TResult ExecuteFunction<TResult>(string name, O7Parameter parameter)
        {
            using (var command = _connection.CreateCommand())
            {
                set_command(command, name, parameter.OracleParameters, get_oracle_type(typeof(TResult)));
                command.ExecuteNonQuery();
                return (TResult) get_last_value(command);
            }
        }

        public IEnumerable<TResult> ExecuteFunction<TResult>(string name, Type mapperType) where TResult : O7Entity
            => ExecuteFunction<TResult>(name, new O7Parameter(), mapperType);

        public IEnumerable<TResult> ExecuteFunction<TResult>(string name, O7Parameter parameter, Type mapperType)
            where TResult : O7Entity
        {
            using (var command = _connection.CreateCommand())
            {
                set_command(command, name, parameter.OracleParameters, OracleDbType.RefCursor);
                command.ExecuteNonQuery();
                var reader = get_reader(get_last_value(command));                
                while (reader.Read())
                {
                    var mapper = make_mapper_instance<TResult>(mapperType);
                    mapper.SetSource(make_instance_o7row(reader));
                    yield return mapper.MapTarget();
                }                
            }
        }        
    }
}