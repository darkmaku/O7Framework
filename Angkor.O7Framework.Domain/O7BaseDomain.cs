// Create by Felix A. Bueno

using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace Angkor.O7Framework.Domain
{
    public class O7BaseDomain : IInterceptor
    {
        public virtual void OnEntry(object objects)
        {
        }

        public virtual void OnExit(ParameterInfo[] objects)
        {
        }

        public virtual void OnException(Exception exception)
        {
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                OnEntry("Excep");                
                invocation.Proceed();
                OnExit(invocation.Method.GetParameters());
            }
            catch (Exception exception)
            {
                OnException(exception);
            }
            
        }
    }
}