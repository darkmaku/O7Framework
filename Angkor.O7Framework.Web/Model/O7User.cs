// Create by Felix A. Bueno

using System.Collections.Generic;

namespace Angkor.O7Framework.Web.Model
{
    public class O7User
    {
        public string Company { get; set; }
        public string Branch { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserApplication { get; }

        public Dictionary<string, string> Atrributes { get; }
        public O7User(string company, string branch, string login, string name, string password,string UserApplication, Dictionary<string, string> atrributes)
        {
            Company = company;
            Branch = branch;
            Login = login;
            Name = name;
            Password = password;
            this.UserApplication = UserApplication;
            Atrributes = atrributes;
        }

        public O7User()
        {
        }
    }
}