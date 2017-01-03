using System;
using System.Dynamic;
using System.Reflection;
using Angkor.O7Framework.Domain;
using Castle.DynamicProxy;
using Angkor.O7Framework.Common;

namespace TestCastleCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var gen = new ProxyGenerator();
            var x = gen.CreateClassProxy<Test>(new O7Proxy());
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

    //public class TestingChild : O7BaseDomain
    //{
    //    public override void OnExit(O7Parameter[] obj)
    //    {
    //        foreach (O7Parameter parameter in obj)
    //        {
    //            Console.WriteLine(parameter.Name);
    //            Console.WriteLine(parameter.Value);
    //        }
    //        Console.WriteLine(obj);
    //    }
    //    public override void OnEntry(object objects)
    //    {            
    //            Console.WriteLine(objects);            
    //    }
    //}

    public class O7Proxy: O7BaseDomain
    {
        public override void OnExit(O7Parameter[] parameters)
        {
            foreach(O7Parameter parameter in parameters)
            {
                Console.WriteLine(parameter.Name);
                Console.WriteLine(parameter.Value);
            }                        
        }
        public override void OnEntry(O7Parameter[] parameters)
        {
            Console.WriteLine("Hola");
            foreach(O7Parameter parameter in parameters)
            {
                Console.WriteLine(parameter.Name);
                Console.WriteLine(parameter.Value);
            }
        }
        public override void OnException(Exception exception)
        {
            base.OnException(exception);
        }
    }

}
