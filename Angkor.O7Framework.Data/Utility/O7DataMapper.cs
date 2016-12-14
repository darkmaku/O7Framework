// Create by Felix A. Bueno

using Angkor.O7Framework.Data.Common;
using Angkor.O7Framework.Utility;

namespace Angkor.O7Framework.Data.Utility
{
    public abstract class O7DataMapper<TEntity> : O7Mapper<O7Row, TEntity> where TEntity : O7Entity
    {
    }
}