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
            Test x = O7ClassLifeCycle.InstanceDomain<Test>();
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
