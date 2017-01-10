using System;
using System.Dynamic;
using System.Reflection;
using Angkor.O7Framework.Common;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Components;
using Angkor.O7Framework.Domain;
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Framework.Web.Security;
using Castle.DynamicProxy;

namespace TestCastleCore
{
    public class Program
    {
        static void Main(string[] args)
        {
//            var x = O7DomainInstanceMaker.MakeInstance<Test, MyClass>(new object[] {"okiwi", "oliwi"}, new object[]{});
//            x.Exec("hola", 5);
//            Console.ReadKey();
            var x = new O7Logger(new O7Principal("fbueno","001", "003", "felix", "100890fF?"), typeof(Program));
            x.AppendError("TestError");
        }      
    }

    public class MyClass : O7AbstractDomain
    {
        public override void OnEntry(O7Parameter[] parameters)
        {
            Console.WriteLine("Entry");
        }

        public override void OnExit(O7Parameter[] parameters)
        {
            Console.WriteLine("Exit");
        }
    }

    public class Test
    {
        private string _x;
        private string _y;
        public Test(string x, string y)
        {
            _x = x;
            _y = y;
        }

        public virtual void Exec(string x, int y)
        {
            Console.WriteLine("Exec");    
            Console.WriteLine(_x);
            Console.WriteLine(_y);
        }

        public virtual string Build()
        {
            return "test";
        }

    }
}
