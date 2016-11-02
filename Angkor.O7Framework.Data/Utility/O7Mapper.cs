// Create by Felix A. Bueno

using Angkor.O7Framework.Data.Common;

namespace Angkor.O7Framework.Data.Utility
{
    public abstract class O7Mapper<T> where T : O7Entity
    {
        protected O7Row O7Row;

        public void SetRow(O7Row o7Row)
        {
            O7Row = o7Row;
        }

        public abstract T Map();
    }
}