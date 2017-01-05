// Create by Felix A. Bueno

using System.Diagnostics.Contracts;

namespace Angkor.O7Framework.Utility
{
    public abstract class O7Mapper<TSource, TTarget>
    {
        protected TSource Source { get; private set; }

        public void SetSource(TSource source)
        {
            Contract.Ensures(source !=null);
            Source = source;
        }

        public abstract TTarget MapTarget();
    }
}