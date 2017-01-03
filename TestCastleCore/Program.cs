using System;
using System.Dynamic;
using System.Reflection;
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
        public override void OnExit(ParameterInfo[] obj)
        {
            foreach (ParameterInfo parameter in obj)
            {
                Console.WriteLine(parameter.Name);
                Console.WriteLine(parameter.ParameterType);
                Console.WriteLine(parameter.);
            }

            Console.WriteLine(obj);
        }

        public override void OnEntry(object objects)
        {
            
                Console.WriteLine(objects);
            
        }
    }

}
