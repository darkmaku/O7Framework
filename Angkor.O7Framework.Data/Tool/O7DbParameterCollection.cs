// Create by Felix A. Bueno

using System.Linq;
using Angkor.O7Framework.Common.Model;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Framework.Data.Tool
{
    public partial class O7DbParameterCollection : O7ParameterCollection
    {        

        public OracleParameter[] DbParameters 
            => build_db_parameters().ToArray();
        
        public new static O7DbParameterCollection Make 
            => new O7DbParameterCollection();

        public new static O7DbParameterCollection MakeFrom(O7ParameterCollection parameterCollection)
            => new O7DbParameterCollection(parameterCollection);

        
    }
}