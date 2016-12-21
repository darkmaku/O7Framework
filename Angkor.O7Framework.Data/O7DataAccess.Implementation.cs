// Create by Felix A. Bueno

using System;
using System.Data;
using System.Reflection;
using Angkor.O7Framework.Data.Common;
using Angkor.O7Framework.Data.Exception;
using Angkor.O7Framework.Data.Utility;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Angkor.O7Framework.Data
{
    public partial class O7DataAccess
    {
        private static O7DataMapper<TResult> make_mapper_instance<TResult>(Type mapperType) where TResult : O7Entity
        {
            var mapper = Activator.CreateInstance(mapperType) as O7DataMapper<TResult>;
            if (mapper == null) throw new AmbiguousMatchException();
            return mapper;
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

        private static OracleDataReader get_reader(object cursor)
        {
            var currentCursor = cursor as OracleRefCursor;
            if (currentCursor == null)
                throw new AmbiguousMatchException();
            return currentCursor.GetDataReader();
        }

        private static void set_command(OracleCommand command, string name, OracleParameter[] parameters,
            OracleDbType type)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = name;
            command.BindByName = true;
            for (var i = 0; i < parameters.Length; i++)
                command.Parameters.Add(parameters[i]);
            command.Parameters.Add(make_return_parameter(type));
        }

        private static OracleParameter make_return_parameter(OracleDbType type)
        {
            if (type == OracleDbType.NVarchar2)
                return new OracleParameter("RETURN", type, ParameterDirection.ReturnValue) {Size = 1000};
            return new OracleParameter("RETURN", type, ParameterDirection.ReturnValue);
        }
    }
}