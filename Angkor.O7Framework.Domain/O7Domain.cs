// Create by Felix A. Bueno

using Castle.DynamicProxy;

namespace Angkor.O7Framework.Domain
{
    public abstract class O7Domain : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();            
        }
    }
}