// Create by Felix A. Bueno

using Angkor.O7Framework.Data.Utility;

namespace Angkor.O7Framework.Data
{
    public abstract class O7DataAccessService
    {
        public string DataConnection { get; private set; }

        protected O7DataAccessService(string login, string password)
        {
            DataConnection = O7Provider.DataBaseConection(login, password);
        }

        public void ChangeDataCredential(string login, string password)
        {
            DataConnection = O7Provider.DataBaseConection(login, password);
        }
    }
}