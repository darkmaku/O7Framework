// Create by Felix A. Bueno

using System;
using System.Collections.Generic;
using System.Data;
using Angkor.O7Framework.Common;
using Angkor.O7Framework.Data.Exception;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Framework.Data.Utility
{
    public class O7DbParameterCollection : O7ParameterCollection
    {
        public O7DbParameterCollection(O7ParameterCollection parameterCollection) : base(parameterCollection)
        {
        }

        public O7DbParameterCollection()
        {
        }

        public OracleParameter[] DbParameters => build_parameters();

        private OracleParameter[] build_parameters()
        {
            var oracleParameters = new List<OracleParameter>();
            foreach (var parameter in Parameters)
            {
                oracleParameters.Add(make_parameter(parameter.Name, parameter.Value));
            }
            return oracleParameters.ToArray();
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

        public new static O7DbParameterCollection Make 
            => new O7DbParameterCollection();

        public new static O7DbParameterCollection MakeFrom(O7ParameterCollection parameterCollection)
            => new O7DbParameterCollection(parameterCollection);
    }
}