using System;
using Angkor.O7Framework.Infrastructure.Data;
using Castle.DynamicProxy;

namespace Angkor.O7Framework.Infrastructure
{
    public class O7DataInstanceMaker
    {
        public static TTarget MakeInstance<TTarget>(object[] targetObjects)
            where TTarget : O7AbstractData
        {
            var proxy = new ProxyGenerator();            
            return (TTarget)proxy.CreateClassProxy(typeof(TTarget), targetObjects, new O7AbstractDataFlow());
        }
    }
}
