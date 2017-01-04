// Create by Felix A. Bueno
namespace Angkor.O7Framework.Common
{
    public class O7ParameterCollection
    {
        private int _length;
        private int _maxLength;

        protected O7ParameterCollection()
        {
            _length = 0;
            _maxLength = 0;            
            Parameters = new O7Parameter[_maxLength];
        }

        protected O7ParameterCollection(O7ParameterCollection parameterCollection)
        {
            _length = parameterCollection._length;
            _maxLength = parameterCollection._maxLength;
            Parameters = parameterCollection.Parameters;
        }

        public static O7ParameterCollection Make
            => new O7ParameterCollection();

        public static O7ParameterCollection MakeFrom(O7ParameterCollection parameterCollection) 
            => new O7ParameterCollection(parameterCollection);

        public O7Parameter[] Parameters { get; private set; } 

        public void Add(O7Parameter parameter)
        {
            if(_length >= _maxLength) increase_collection();
            Parameters[_length] = parameter;
            _length++;
        }

        private void increase_collection()
        {
            var increase = _maxLength + 1;
            var temporal = new O7Parameter[increase];
            for (var i = 0; i < _maxLength; i++) temporal[i] = Parameters[i];
            Parameters = temporal;
            _maxLength = increase;
        }
    }
}