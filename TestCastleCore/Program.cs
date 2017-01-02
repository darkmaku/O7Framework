using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace TestCastleCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var generator = new ProxyGenerator();
            var x = generator.CreateClassProxy<Test>(new Testing());
            var y = x.Exec();
            Console.WriteLine(y);
            Console.ReadKey();
        }
    }

    public class Test
    {
        public virtual string Exec()
        {
            var test = "Test";
            Console.WriteLine(test);
            throw new Exception();
            return test;
        }

    }

    public class Testing : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                Pre();
                invocation.Proceed();
                Post();
                invocation.ReturnValue = "Hola";
            }
            catch
            {
                invocation.ReturnValue = "Error";
            }
            
        }

        public virtual void Pre()
        {
            Console.WriteLine("Pre");
        }

        public virtual void Post()
        {
            Console.WriteLine("Post");
        }
    }
}
