using System.Diagnostics.Contracts;
using Angkor.O7Framework.Utility;

namespace Angkor.O7Framework.Data.Utility
{
    public class DataBaseValidator
    {
        [ContractArgumentValidator]
        public static void ValidConnection(string connection)
        {
            if(connection.GetValueFrom("data source").Contains("/"))
                throw new System.Exception();
            if (string.IsNullOrEmpty(connection.GetValueFrom("user id")))
                throw new System.Exception();
            if (string.IsNullOrEmpty(connection.GetValueFrom("password")))
                throw new System.Exception();
            Contract.EndContractBlock();
        }       
    }
}
