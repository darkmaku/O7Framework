using System.Diagnostics.Contracts;
using Angkor.O7Framework.Utility;

namespace Angkor.O7Framework.Data.Utility
{
    class DataBaseValidatorHelper
    {
        [ContractArgumentValidator]
        public static void ValidConnection(string connection)
        {
            if(connection.GetValueFrom("Data base").Contains("/"))
                throw new System.Exception();
            if (string.IsNullOrEmpty(connection.GetValueFrom("user id")))
                throw new System.Exception();
            if (string.IsNullOrEmpty(connection.GetValueFrom("password")))
                throw new System.Exception();
            Contract.EndContractBlock();
        }


    }
}
