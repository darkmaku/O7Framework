// Create by Felix A. Bueno

using System;
using System.Data;
using System.Reflection;
using Angkor.O7Framework.Data.Exception;
using Angkor.O7Framework.Data.Utility;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Angkor.O7Framework.Data
{
    public partial class O7DbAccess
    {
        private static O7DbMapper<TResult> make_mapper_instance<TResult>(Type mapperType)
            => (O7DbMapper<TResult>)Activator.CreateInstance(mapperType);
        

        private static O7DbRowReader make_instance_o7row(OracleDataReader reader)
        {
            var rowType = typeof(O7DbRowReader);
            var parameters = new[] {typeof(OracleDataReader)};
            var constructor = rowType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, parameters,
                null);
            return (O7DbRowReader) constructor.Invoke(new[] {reader});
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
            var currentCursor = (OracleRefCursor)cursor;
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