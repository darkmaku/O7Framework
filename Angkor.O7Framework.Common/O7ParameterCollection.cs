// Create by Felix A. Bueno
namespace Angkor.O7Framework.Common
{
    public class O7ParameterCollection
    {
        private int _length;
        private int _maxLength;

        protected O7ParameterCollection()
        {
            Parameters = new O7Parameter[_maxLength];
            _maxLength = 1;
            _length = 0;
        }

        protected O7ParameterCollection(O7ParameterCollection parameterCollection)
        {            
            Parameters = parameterCollection.Parameters;
            _length = parameterCollection._length;
            _maxLength = parameterCollection._maxLength;
        }

        public static O7ParameterCollection Make => new O7ParameterCollection();
        public static O7ParameterCollection MakeFrom(O7ParameterCollection parameterCollection) => new O7ParameterCollection(parameterCollection);

        public O7Parameter[] Parameters { get; private set; }
        
        public void Add(O7Parameter parameter)
        {
            if(_length >= _maxLength) increase_collection();
            Parameters[_length] = parameter;
            _length++;
        }

        private void increase_collection()
        {
            var increase = _maxLength + 2;
            var temporal = new O7Parameter[increase];
            for (var i = 0; i < _maxLength; i++) temporal[i] = Parameters[i];
            Parameters = temporal;
            _maxLength = increase;
        }
    }
}