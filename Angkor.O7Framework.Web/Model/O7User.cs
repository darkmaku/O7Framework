// Create by Felix A. Bueno

using System.Collections.Generic;

namespace Angkor.O7Framework.Web.Model
{
    public class O7User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        public string Name { get; set; }

        public string UserApplication { get; set; }
        public Dictionary<string, string> Attributes { get; set; }

        public O7User()
        {
        }

        public O7User(string company, string branch, string login, string name, string password, string userApplication, Dictionary<string, string> attributes
            )
        {
            Login = login;
            Password = password;
            Company = company;
            Branch = branch;
            Name = name;
            UserApplication = userApplication;
            Attributes = attributes;
        }
    }
}