// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Data;

namespace Angkor.O7Framework.Infraestructure
{
    public class O7AbstractData : IDisposable
    {
        private O7DataAccess _dataAccess;

        protected O7DataAccess GetDataAccess() 
            => _dataAccess;

        public void Dispose()
        {
            _dataAccess = null;
            GC.Collect();
        }
    }
}