using System.Security.Principal;

namespace Angkor.O7Framework.Web.Model
{
    public class O7Principal : IPrincipal
    {
        #region BaseAttributes    
        public bool IsInRole(string role) => true;        
        public IIdentity Identity { get; }
        #endregion

        public string Company { get;}
        public string Branch { get;  }
        public string Name { get; }
        public string Password { get; }
        public O7Principal(string login, string company, string branch, string name, string password)
        {
            Identity = new GenericIdentity(login);
            Company = company;
            Branch = branch;
            Name = name;
            Password = password;
        }
    }
}
