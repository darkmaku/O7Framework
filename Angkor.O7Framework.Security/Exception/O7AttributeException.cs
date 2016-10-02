// Create by Felix A. Bueno
namespace Angkor.O7Framework.Utility.Exception
{
    public class O7AttributeException : System.Exception
    {
        protected O7AttributeException(string message) : base(message)
        {
        }

        public static O7AttributeException MakeGetterException => new O7AttributeException("No se puede obtener valor.");
    }
}