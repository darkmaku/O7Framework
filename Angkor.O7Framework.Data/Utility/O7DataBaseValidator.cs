using System;
using System.Data;
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
        }        
        
        public static bool ConnectionIsOpened(OracleConnection connection)
            => connection.State == ConnectionState.Open;            
                
    }
}
