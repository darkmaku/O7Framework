using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angkor.O7Framework.Common;
using Castle.DynamicProxy;

namespace Angkor.O7Framework.Domain
{
    public class O7DomainBuilder
    {
        public static TestClass Build<TestClass>() where TestClass : class
        {
            return new ProxyGenerator().CreateClassProxy<TestClass>(new O7Domain());
        }
    }
}
