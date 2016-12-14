// Create by Felix A. Bueno

using System;
using System.Reflection;
using Angkor.O7Framework.Domain.Response;
using Oracle.ManagedDataAccess.Client;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Angkor.O7Framework.Domain
{
    [PSerializable]
    public class O7DomainExceptionAttribute : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {                                    
            args.FlowBehavior = FlowBehavior.Return;
            args.ReturnValue = build_response(args.Exception);
        }

        private static O7ErrorResponse build_response(Exception exception)
        {
            var oracleException = exception as OracleException;
            return oracleException == null
                ? new O7ErrorResponse(400, $"Message:{exception.Message}")
                : new O7ErrorResponse(401, $"Code:{oracleException.ErrorCode} Message:{oracleException.Message}");
        }
    }
}