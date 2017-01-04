using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angkor.O7Framework.Common;
using Castle.DynamicProxy;

namespace Angkor.O7Framework.Domain
{
    public class O7ClassLifeCycle
    {
        public static TestClass InstanceDomain<TestClass>() where TestClass : class
        {
            return new ProxyGenerator().CreateClassProxy<TestClass>(new O7Proxy());
        }
    }


    public class O7Proxy : O7AbstractDomain
    {
        public override void OnEntry(O7Parameter[] parameters)
        {
            foreach (var parameter in parameters)
            {
                Console.WriteLine("Name: " + parameter.Name);
                Console.WriteLine("Value: " + parameter.Value);
            }
        }

        public override void OnExit(O7Parameter[] parameters)
        {
            foreach (var parameter in parameters)
            {
                Console.WriteLine("Name: " + parameter.Name);
                Console.WriteLine("Value: " + parameter.Value);
            }
            //SetReturnValue("oliwi");
        }

        public override void OnException(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}
