// Create for Felix A. Bueno

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Angkor.O7Framework.Data.Exception;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Framework.Data.Common
{
    public class O7Parameter
    {
        private readonly HashSet<OracleParameter> _parameters;

        public O7Parameter(OracleParameter[] parameter)
        {
            _parameters = new HashSet<OracleParameter>(parameter);
        }

        public O7Parameter()
        {
            _parameters = new HashSet<OracleParameter>();
        }

        public OracleParameter[] OracleParameters => _parameters.ToArray();         

        public bool HasParameters => _parameters.Count > 0;

        public void Add(string name, object value)
        {
            _parameters.Add(make_parameter(name, value));
        }

        private static OracleParameter make_parameter(string name, object value)
        {
            var parameter = new OracleParameter(name, get_oracle_type(value.GetType()));
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
            throw O7DataException.MakeMatchException;
        }
    }
}