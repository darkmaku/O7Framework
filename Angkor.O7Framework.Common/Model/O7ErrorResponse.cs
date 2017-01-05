// Create by Felix A. Bueno
namespace Angkor.O7Framework.Domain.Response
{
    public class O7ErrorResponse : O7Response<int, string>
    {
        public O7ErrorResponse(int value1, string value2) : base(value1, value2)
        {
        }

        public int Code => Item1;

        public string Message => Item2;

    }
}