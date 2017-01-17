using System;
using System.Collections.Generic;
using System.Reflection;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Framework.Infrastructure.Data;
using Castle.DynamicProxy;

namespace TestCastleCore
{
    public class SecurityDataService : O7AbstractData
    {
        public SecurityDataService(string login, string password) : base(login, password)
        {
        }

        public virtual string ValidAccess(string companyId, string branchId, string menuId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_menu_id", menuId));
            return DataAccess.ExecuteFunction<string>("security.is_permited", parameters);
        }

        public virtual string UserName(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            return DataAccess.ExecuteFunction<string>("security.get_user_name", parameters);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var x = O7DataInstanceMaker.MakeInstance<SecurityDataService>(new object[] { "CN01", "CN01" });
            var result = x.UserName("001", "001");
            Console.WriteLine(result);
            //var proxy = new ProxyGenerator();           
            //var x = proxy.CreateClassProxy<MyClass2>(new MyClass());
            //x.Exec();
            //Console.ReadKey();
            //            var x = O7DomainInstanceMaker.MakeInstance<Test, MyClass>(new object[] {"okiwi", "oliwi"}, new object[]{});
            //            x.Exec("hola", 5);
            //            Console.ReadKey();
            //            var x = new O7Logger(new O7Principal("fbueno","001", "003", "felix", "100890fF?"), typeof(Program));
            //            x.AppendError("TestError");
        }      
    }

    public abstract class MyClass3
    {
        public void Consol3()
        {
            Console.WriteLine("Console3");
        }

        public abstract void Exec();

        public abstract void Consol();
    }

    public class MyClass2:MyClass3
    {
        public override void Exec()
        {
            Console.WriteLine("exec");
        }

        public override void Consol()
        {
            Console.WriteLine("Console");
        }
    }

    public class MyClass:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var classType = invocation.TargetType;
            var classInstance = Activator.CreateInstance(classType);
            var method = classType.GetMethod("Consol3");
            method.Invoke(classInstance, null);            
            Console.WriteLine("oli");
            invocation.Proceed();
        }
    }

//    public class MyClass : O7AbstractDomain
//    {
//        public override void OnEntry(O7Parameter[] parameters)
//        {
//            Console.WriteLine("Entry");
//        }
//
//        public override void OnExit(O7Parameter[] parameters)
//        {
//            Console.WriteLine("Exit");
//        }
//    }

    public class Test
    {
        private string _x;
        private string _y;
        public Test(string x, string y)
        {
            _x = x;
            _y = y;
        }

        public virtual void Exec(string x, int y)
        {
            Console.WriteLine("Exec");    
            Console.WriteLine(_x);
            Console.WriteLine(_y);
        }

        public virtual string Build()
        {
            return "test";
        }

    }
}
