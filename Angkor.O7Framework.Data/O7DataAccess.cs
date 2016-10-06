// Created by Felix A. Bueno in 29/09/2016

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Angkor.O7Framework.Data.Common;
using Angkor.O7Framework.Data.Exception;
using Angkor.O7Framework.Data.Utility;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Angkor.O7Framework.Data
{
    public class O7DataAccess : IDisposable
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

        public TResult ExecuteFunction<TResult>(string name, O7Parameter parameter)
            where TResult : struct
        {
            using (var command = _connection.CreateCommand())
            {
                set_command(command, name, parameter.OracleParameters, get_oracle_type(typeof(TResult)));
                command.ExecuteNonQuery();
                return (TResult) get_last_value(command);
            }
        }

        public TResult[] ExecuteFunction<TResult>(string name, O7Parameter parameter,
            Func<O7Row, TResult> function) where TResult : O7Entity
        {
            using (var command = _connection.CreateCommand())
            {
                set_command(command, name, parameter.OracleParameters, OracleDbType.RefCursor);
                command.ExecuteNonQuery();
                var reader = get_reader(get_last_value(command) as OracleRefCursor);
                var result = new List<TResult>();
                while (reader.Read())
                    result.Add(function.Invoke(make_instance_o7row(reader)));
                return result.ToArray();
            }
        }

        private static O7Row make_instance_o7row(OracleDataReader reader)
        {
            var rowType = typeof(O7Row);
            var parameters = new[] {typeof(OracleDataReader)};
            var constructor = rowType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, parameters,
                null);
            return (O7Row) constructor.Invoke(new[] {reader});
        }

        private static OracleDbType get_oracle_type(Type dataType)
        {
            if (dataType == typeof(string))
                return OracleDbType.NVarchar2;
            if (dataType == typeof(int))
                return OracleDbType.Int32;
            if (dataType == typeof(double))
                return OracleDbType.Double;
            throw O7DataException.MakeMatchException;
        }

        private static object get_last_value(OracleCommand command)
        {
            var length = command.Parameters.Count - 1;
            return command.Parameters[length].Value;
        }

        private static OracleDataReader get_reader(OracleRefCursor cursor)
        {
            if (cursor == null)
                throw new AmbiguousMatchException();
            return cursor.GetDataReader();
        }

        private static void set_command(OracleCommand command, string name, OracleParameter[] parameters,
            OracleDbType type)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = name;
            command.BindByName = true;
            for (var i = 0; i < parameters.Length; i++)
                command.Parameters.Add(parameters[i]);
            command.Parameters.Add(new OracleParameter("RETURN", type, ParameterDirection.ReturnValue));
        }
    }
}