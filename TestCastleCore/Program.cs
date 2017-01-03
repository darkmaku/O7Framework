using System;
using System.Dynamic;
using System.Reflection;
using Angkor.O7Framework.Common;
using Angkor.O7Framework.Domain;
using Castle.DynamicProxy;

namespace TestCastleCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var gen = new ProxyGenerator();
            var x = gen.CreateClassProxy<Test>(new TestingChild());
            x.Exec("string", 0);
            Console.ReadKey();
        }
    }

    public class Test
    {
        public virtual void Exec(string x, int y)
        {
            Console.WriteLine("Exec");            
        }
    }

    public class TestingChild : O7BaseDomain
    {
        public override void OnEntry(O7Parameter[] parameters)
        {
            foreach (var parameter in parameters)
            {
                Console.WriteLine("Name"+parameter.Name);
                Console.WriteLine("Value" + parameter.Value);
            }
        }

        public override void OnExit(O7Parameter[] parameters)
        {
            foreach (var parameter in parameters)
            {
                Console.WriteLine("Name" + parameter.Name);
                Console.WriteLine("Value" + parameter.Value);
            }
        }
    }

}
