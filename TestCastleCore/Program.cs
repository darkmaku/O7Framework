using System;
using System.Dynamic;
using System.Reflection;
using Angkor.O7Framework.Common;
using Angkor.O7Framework.Domain;
using Angkor.O7Framework.Infrastructure;
using Castle.DynamicProxy;

namespace TestCastleCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var x = O7DomainAccess.MakeInstance<Test, O7AbstractDomain>(null);
            x.Exec("hola", 5);
            Console.ReadKey();
        }
    }

    public class Test
    {
        public virtual void Exec(string x, int y)
        {
            Console.WriteLine("Exec");                        
        }

        public virtual string Build()
        {
            return "test";
        }

    }
}
