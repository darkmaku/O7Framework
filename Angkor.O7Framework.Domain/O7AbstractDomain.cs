// Create by Felix A. Bueno

using System;
using System.Reflection;
using Angkor.O7Framework.Common;
using Castle.DynamicProxy;

namespace Angkor.O7Framework.Domain
{
    public abstract class O7AbstractDomain : IInterceptor
    {
        private IInvocation _invocation;

        public virtual void OnEntry(O7Parameter[] parameters)
        {
        }

        public virtual void OnExit(O7Parameter[] parameters)
        {
        }

        public virtual void OnException(Exception exception)
        {
        }

        public void SetReturnValue(object returnValue)
        {
            _invocation.ReturnValue = returnValue;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                _invocation = invocation;
                OnEntry(build_parameters(_invocation));
                invocation.Proceed();
                OnExit(build_parameters(_invocation));
            }
            catch (Exception exception)
            {
                OnException(exception);
            }
            
        }

        private O7Parameter[] build_parameters(IInvocation invocation)
        {
            var parameters = invocation.Method.GetParameters();
            var values = invocation.Arguments;
            return build_parameter_collection(parameters, values);
        }

        private O7Parameter[] build_parameter_collection(ParameterInfo[] parameters, object[] values)
        {
            var collection = O7ParameterCollection.Make;
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                var position = parameter.Position;
                var value = values[position];
                collection.Add(O7Parameter.Make(parameter.Name, value));
            }
            return collection.Parameters;
        }
    }
}