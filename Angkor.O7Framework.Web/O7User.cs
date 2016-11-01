// Create by Felix A. Bueno

namespace Angkor.O7Framework.Web
{
    public class O7User
    {
        public string Company { get; }
        public string Branch { get; }
        public string Login { get; }
        public string Name { get; }
        public string Password { get; }

        public O7User(string company, string branch, string login, string name, string password)
        {
            Company = company;
            Branch = branch;
            Login = login;
            Name = name;
            Password = password;
        }
    }
}