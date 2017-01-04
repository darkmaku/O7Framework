using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Remoting.Messaging;
using Angkor.O7Framework.Common.Validator;
using Angkor.O7Framework.Utility;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Framework.Data.Utility
{
    public class O7DataBaseValidator
    {
        public static bool ValidConnection(string connection)
        {
            if (!connection.GetValueFrom("data source").Contains("/"))
                return false;
            if (string.IsNullOrEmpty(connection.GetValueFrom("user id")))
                return false;
            if (string.IsNullOrEmpty(connection.GetValueFrom("password")))
                return false;
            return true;
            //Contract.EndContractBlock();
        }

        //[ContractArgumentValidator]
        public static bool ConnectionClose(OracleConnection connection)
        {
            //Contract.Ensures(connection.State == ConnectionState.Closed);
            if (connection.State != ConnectionState.Closed) return false;
            return true;
            //Contract.EndContractBlock();
        }

        //[ContractArgumentValidator]
        public static bool ConnectionOpen(OracleConnection connection)
        {
            if (connection.State == ConnectionState.Closed) return false;
            return true;
            //Contract.EndContractBlock();
        }

        public static bool ValidName(string name) => String.IsNullOrEmpty(name);

        public static bool ValidStrings(params string[] s) => StringsValidator.AllNotNull(s);

        public static bool ValidExecuteParameters(string name, O7DbParameterCollection parametersCollection,
            Type mapperType)=> O7DataBaseValidator.ValidStrings(name) && parametersCollection != null && mapperType != null;
        
        public static bool ValidExecuteParameters(string name, O7DbParameterCollection parametersCollection) =>!string.IsNullOrEmpty(name) && parametersCollection != null;
        
    }
}
