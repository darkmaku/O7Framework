// Create by Felix A. Bueno

using System.Diagnostics.Contracts;

namespace Angkor.O7Framework.Common
{
    public class O7Parameter
    {
        public string Name { get; private set; }
        public object Value { get; private set; }

        private O7Parameter(string name, object value)
        {
            Contract.Requires(!string.IsNullOrEmpty(name));
            Name = name;
            Value = value;
        }

        public static O7Parameter Make(string name, object value)
            => new O7Parameter(name, value);
    }
}