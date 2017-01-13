// Create by Felix A. Bueno
namespace Angkor.O7Framework.Common.Model
{
    public class O7ErrorResponse : O7Response<string>
    {
        protected O7ErrorResponse(string value1) : base(value1)
        { }

        public string Message => Item1;

        public static O7ErrorResponse Make(string value)
            => new O7ErrorResponse(value);
    }
}