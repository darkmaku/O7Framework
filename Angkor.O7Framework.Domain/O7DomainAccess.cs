using System;
using Angkor.O7Framework.Infrastructure;
using Castle.DynamicProxy;

namespace Angkor.O7Framework.Domain
{
    public class O7DomainAccess
    {
        public static TClass MakeInstance<TClass,TDomain>(object[] parameters) 
            where TDomain : O7AbstractDomain where TClass : class
        {
            var typeDomain = typeof(TDomain);
            var flowDomain = (TDomain) Activator.CreateInstance(typeDomain, parameters);
            return new ProxyGenerator().CreateClassProxy<TClass>(flowDomain);
        }
    }
}
