// Create by Felix A. Bueno

namespace Angkor.O7Framework.Web.Security
{
    public class O7User
    {
        public string Company { get; set; }
        public string Branch { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public O7User(string company, string branch, string login, string name, string password)
        {
            Company = company;
            Branch = branch;
            Login = login;
            Name = name;
            Password = password;
        }

        public O7User()
        {
        }
    }
}