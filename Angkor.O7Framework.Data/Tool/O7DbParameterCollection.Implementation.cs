// Create by Felix A. Bueno

using System;
using System.Collections.Generic;
using System.Data;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Data.Exception;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Framework.Data.Tool
{
    public partial class O7DbParameterCollection
    {
        protected O7DbParameterCollection(O7ParameterCollection parameterCollection) : base(parameterCollection)
        {
        }

        protected O7DbParameterCollection()
        {
        }

        private IEnumerable<OracleParameter> build_db_parameters()
        {
            for (var i = 0; i < Parameters.Length; i++)
            {
                var parameter = Parameters[i];
                yield return make_parameter(parameter.Name, parameter.Value);
            }
        }

        private static OracleParameter make_parameter(string name, object value)
        {
            var parameter = new OracleParameter(name, get_oracle_type(value?.GetType() ?? typeof(string)));
            parameter.Value = value;
            parameter.Direction = ParameterDirection.Input;
            return parameter;
        }

        private static OracleDbType get_oracle_type(Type dataType)
        {
            if (dataType == typeof(string))
                return OracleDbType.NVarchar2;
            if (dataType == typeof(int))
                return OracleDbType.Int32;
            if (dataType == typeof(double))
                return OracleDbType.Double;
            if (dataType.IsArray)
                return OracleDbType.Clob;
            throw O7DataException.MakeMatchException;
        }
    }
}