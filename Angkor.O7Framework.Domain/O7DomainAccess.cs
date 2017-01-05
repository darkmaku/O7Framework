using System;
using Angkor.O7Framework.Infraestructure;
using Castle.DynamicProxy;

namespace Angkor.O7Framework.Domain
{
    public class O7DomainAccess
    {
        public static TClass MakeInstance<TClass,TDomain>() 
            where TDomain : O7AbstractDomain where TClass : class
        {
            var typeDomain = typeof(TDomain);
            var flowDomain = (TDomain) Activator.CreateInstance(typeDomain);
            return new ProxyGenerator().CreateClassProxy<TClass>(flowDomain);
        }
    }
}
