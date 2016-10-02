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
        private HashSet<OracleParameter> _parameters;

        public OracleParameter[] OracleParameters
        {
            get
            {
                if (!HasParameters) throw O7DataException.MakeParameterException;
                return _parameters.ToArray();
            }
        }

        public O7Parameter(OracleParameter[] parameter)
        {
            _parameters = new HashSet<OracleParameter>(parameter);
        }

        public O7Parameter()
        {
            _parameters = new HashSet<OracleParameter>();
        }

        public void Add(string name, O7DataType type, int typeSize, object value)
        {
            _parameters.Add(new OracleParameter(name, get_oracle_type(type), typeSize, value, ParameterDirection.Input));
        }

        public bool HasParameters => _parameters.Count > 0;

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
    }
}