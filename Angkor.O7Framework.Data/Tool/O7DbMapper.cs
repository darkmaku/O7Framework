// Create by Felix A. Bueno

using Angkor.O7Framework.Data.Common;
using Angkor.O7Framework.Utility;

namespace Angkor.O7Framework.Data.Utility
{
    public abstract class O7DbMapper<TEntity> : O7Mapper<O7DbRowReader, TEntity> 
    {
    }
}