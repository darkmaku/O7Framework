// Created by Felix A. Bueno in 29/09/2016

namespace Angkor.O7Framework.Data.Exception
{
    public class O7DataException : System.Exception
    {
        public O7DataException (string message) : base (message)
        {}

        public static O7DataException MakeConnectionException => new O7DataException ("Don't set O7Connection");

        public static O7DataException MakeParameterException => new O7DataException("Don't set parameters in O7Parameter");

        public static O7DataException MakeMatchException => new O7DataException("Doesn't have parameter type");
    }
}