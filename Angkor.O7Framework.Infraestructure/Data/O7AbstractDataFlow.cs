// O7Framework created by felix_dev
using Castle.DynamicProxy;

namespace Angkor.O7Framework.Infrastructure.Data
{
    public class O7AbstractDataFlow : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {            
            var classType = invocation.TargetType;            
            var openMethod = classType.GetMethod("OpenDataAccess");
            var closeMethod = classType.GetMethod("CloseDataAccess");            
            openMethod.Invoke(invocation.InvocationTarget, null);
            invocation.Proceed();            
            closeMethod.Invoke(invocation.InvocationTarget, null);
        }
    }
}