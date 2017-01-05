using System.Data;
using Angkor.O7Framework.Common.Validator;
using Angkor.O7Framework.Utility;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Framework.Data.Utility
{
    public class O7DbValidator
    {
        public static bool ValidConnection(string connection)
            => ContractValidator.StringIsNotNullOrEmpty(connection.GetValueFrom("user id")) &&
               ContractValidator.StringIsNotNullOrEmpty(connection.GetValueFrom("password")) &&
               connection.GetValueFrom("data source").Contains("/");            
                        
        public static bool ConnectionIsOpened(OracleConnection connection)
            => connection.State == ConnectionState.Open;            
                
    }
}
