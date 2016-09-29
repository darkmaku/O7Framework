// Create for Felix A. Bueno

using System.Collections.Generic;
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
                if(!HasParameters) throw O7DataException.MakeParameterException;
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

        public void Add(OracleParameter parameter)
        {
            _parameters.Add(parameter);
        }

        public bool HasParameters => _parameters.Count > 0;
    }
}