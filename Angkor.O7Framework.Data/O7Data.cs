// Created by Felix A. Bueno in 29/09/2016

using Angkor.O7Framework.Data.Common;

namespace Angkor.O7Framework.Data
{
    public abstract class O7Data
    {
        public abstract TEntity[] ExecuteProcedure<TEntity> (string name, params object[] parameters) where TEntity : O7Entity;

        public abstract bool ExecuteFunction<TEntity> (string name, params object[] parameters) where TEntity : O7Entity;
    }
}