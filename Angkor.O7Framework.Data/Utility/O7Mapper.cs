// Create by Felix A. Bueno
namespace Angkor.O7Framework.Data.Utility
{
    public abstract class O7Mapper<T> where T : class
    {
        protected O7Row O7Row;

        public void SetRow(O7Row o7Row)
        {
            O7Row = o7Row;
        }

        public abstract T Map();
    }
}