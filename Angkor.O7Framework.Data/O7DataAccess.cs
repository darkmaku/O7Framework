// Created by Felix A. Bueno in 29/09/2016

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Angkor.O7Framework.Data.Common;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Angkor.O7Framework.Data
{
    public class O7DataAccess : IDisposable
    {
        private OracleConnection _connection;

        public O7DataAccess(string connection)
        {
            _connection = new OracleConnection(connection);
            _connection.Open();
        }

        public TResult ExecuteFunction<TResult>(string name, O7Parameter parameter, O7DataType type)
            where TResult : struct
        {
            using (var command = _connection.CreateCommand())
            {
                set_command(command, name, parameter.OracleParameters, get_oracle_type(type));
                command.ExecuteNonQuery();
                return (TResult) get_last_value(command);
            }
        }

        public TResult[] ExecuteFunction<TResult>(string name, O7Parameter parameter, O7DataType type,
            Func<OracleDataReader, TResult> function) where TResult : O7Entity
        {            
            using (var command = _connection.CreateCommand())
            {
                set_command(command, name, parameter.OracleParameters, get_oracle_type(type));                
                command.ExecuteNonQuery();
                var reader = get_reader(get_last_value(command) as OracleRefCursor);
                var result = new List<TResult>();
                while (reader.Read())
                    result.Add(function.Invoke(reader));
                return result.ToArray();
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }        

        private static OracleDbType get_oracle_type(O7DataType dataType)
        {
            switch (dataType)
            {
                case O7DataType.Char:
                    return OracleDbType.Char;
                case O7DataType.NChar:
                    return OracleDbType.NChar;
                case O7DataType.Varchar2:
                    return OracleDbType.Varchar2;
                case O7DataType.Blob:
                    return OracleDbType.Blob;
                case O7DataType.Date:
                    return OracleDbType.Date;
                case O7DataType.Decimal:
                    return OracleDbType.Decimal;
                case O7DataType.Double:
                    return OracleDbType.Double;
                case O7DataType.Long:
                    return OracleDbType.Long;
                case O7DataType.Int16:
                    return OracleDbType.Int16;
                case O7DataType.Int32:
                    return OracleDbType.Int32;
                case O7DataType.Int64:
                    return OracleDbType.Int64;
                case O7DataType.NVarchar2:
                    return OracleDbType.NVarchar2;
                case O7DataType.RefCursor:
                    return OracleDbType.RefCursor;
                case O7DataType.Single:
                    return OracleDbType.Single;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
            }
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

        private static void set_command(OracleCommand command, string name, OracleParameter[] parameters, OracleDbType type)
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