// Create by Felix A. Bueno
namespace Angkor.O7Framework.Web.Exception
{
    public class O7WebSourceException : System.Exception
    {
        protected O7WebSourceException(string message) : base(message)
        {
        }

        public static O7WebSourceException MakeWebSourceException => new O7WebSourceException("Don't set O7WebSource");
    }
}