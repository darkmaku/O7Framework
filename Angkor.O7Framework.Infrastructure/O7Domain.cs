// Create by Felix A. Bueno

using System;

namespace Angkor.O7Framework.Infrastructure
{
    public class O7Domain : IDisposable
    {
        protected string Login;
        protected string Password;

        protected O7Domain(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public void Dispose()
        {
            //TODO: usar colector de basura para limpiar memoria de los acceso a datos.
        }
    }
}