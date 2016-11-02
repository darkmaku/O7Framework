using System;
using Angkor.O7Framework.Data.Exception;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Framework.Data.Utility
{
    public class O7Row
    {
        private readonly OracleDataReader _reader;

        protected O7Row(OracleDataReader reader)
        {
            _reader = reader;
        }

        public TValue GetValue<TValue>(int index)
        {
            var result = _reader.GetValue(index);
            if (typeof(TValue) == typeof(string))
                return (TValue) Convert.ChangeType(result ?? string.Empty, typeof(string));
            if (typeof(TValue) == typeof(int))
                return (TValue) Convert.ChangeType(result, typeof(int));
            if (typeof(TValue) == typeof(double))
                return (TValue) Convert.ChangeType(result, typeof(double));
            throw O7DataException.MakeMatchException;
        }
    }
}