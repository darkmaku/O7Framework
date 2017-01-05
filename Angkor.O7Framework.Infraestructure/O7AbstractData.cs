// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Data;
using Angkor.O7Framework.Data.Utility;

namespace Angkor.O7Framework.Infraestructure
{
    public class O7AbstractData : IDisposable
    {
        private O7DbAccess _dataAccess;

        public O7AbstractData(string user, string password)
        {
            _dataAccess = O7DbAccess.Make(O7DbComponent.BuildDbConection(user, password));
        }

        protected O7DbAccess GetDataAccess() 
            => _dataAccess;

        public void Dispose()
        {
            _dataAccess = null;
            GC.Collect();
        }
    }
}