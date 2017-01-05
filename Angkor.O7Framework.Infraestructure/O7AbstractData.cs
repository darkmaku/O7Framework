// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Data;
using Angkor.O7Framework.Data.Tool;

namespace Angkor.O7Framework.Infrastructure
{
    public class O7AbstractData : IDisposable
    {
        protected O7DbAccess DataAccess { get; private set; }

        public O7AbstractData(string user, string password)
        {
            DataAccess = O7DbAccess.Make(O7DbComponent.BuildDbConection(user, password));
        }
        
        public void Dispose()
        {
            DataAccess = null;
            GC.Collect();
        }
    }
}