// Created by Felix A. Bueno in 29/09/2016

using System;
using System.Collections.Generic;
using System.Data;
using Angkor.O7Framework.Data.Common;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Framework.Data
{
    public class O7Data : IDisposable
    {
        private OracleConnection _connection;

        public O7Data(string connection)
        {
            _connection = new OracleConnection(connection);
        }

        public TEntity[] ExecuteProcedure<TEntity>(string name, O7Parameter parameter, Func<OracleDataReader, TEntity> function)
            where TEntity : O7Entity
        {
            var result = new List<TEntity>();
            using (var command = _connection.CreateCommand())
            {
                SetCommand(command, name, parameter);
                var reader = command.ExecuteReader();
                while (reader.Read())                
                    result.Add(function.Invoke(reader));                
            }
            return result.ToArray();
        }

        public bool ExecuteFunction(string name, O7Parameter parameter)
        {
            using (var command = _connection.CreateCommand())
            {
                SetCommand(command, name, parameter);                
                return command.ExecuteNonQuery() != 0;
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        private static void SetCommand(OracleCommand command, string name, O7Parameter parameter)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = name;
            command.Parameters.Add(parameter.OracleParameters);
        }
    }
}