using System;
using Angkor.O7Framework.Infrastructure;
using Castle.DynamicProxy;

namespace Angkor.O7Framework.Domain
{
    public class O7DomainInstanceMaker
    {
        public static TTarget MakeInstance<TTarget,TDomain>(object[] targetObjects, object[] domainObjects)
            where TTarget : class where TDomain : O7AbstractDomain
        {
            var proxy = new ProxyGenerator();
            var typeDomain = typeof(TDomain);
            var flowDomain = (TDomain)Activator.CreateInstance(typeDomain, domainObjects);
            return (TTarget) proxy.CreateClassProxy(typeof(TTarget), targetObjects, flowDomain);
        }
    }
}
