// Create by Felix A. Bueno
namespace Angkor.O7Framework.Utility
{
    public abstract class O7Mapper<TSource, TTarget>
    {
        protected TSource Source { get; private set; }

        public void SetSource(TSource source)
        {
            Source = source;
        }

        public abstract TTarget MapTarget();
    }
}