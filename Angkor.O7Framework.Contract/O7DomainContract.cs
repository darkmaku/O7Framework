// Create by Felix A. Bueno
namespace Angkor.O7Framework.Contract
{
    public struct O7DomainContract
    {
        public bool Result;
        public dynamic Response;

        public O7DomainContract(bool result, dynamic response)
        {
            Result = result;
            Response = response;
        }
    }
}