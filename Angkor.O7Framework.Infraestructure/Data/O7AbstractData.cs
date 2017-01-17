// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Data;
using Angkor.O7Framework.Data.Tool;

namespace Angkor.O7Framework.Infrastructure.Data
{
    public abstract class O7AbstractData
    {
        private readonly string _login;
        private readonly string _password;

        protected O7DbAccess DataAccess { get; private set; }

        protected O7AbstractData(string user, string password)
        {
            _login = user;
            _password = password;            
        }

        public void OpenDataAccess()
        {
            DataAccess = O7DbAccess.Make(O7DbComponent.BuildDbConection(_login, _password));
        }

        public void CloseDataAccess()
        {
            DataAccess = null;
            GC.Collect();
        }
    }
}