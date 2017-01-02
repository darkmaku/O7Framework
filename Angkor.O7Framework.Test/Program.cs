using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Angkor.O7Framework.Data;
using Angkor.O7Framework.Data.Common;
using Angkor.O7Framework.Data.Utility;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.HtmlHelper;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Framework.Test
{
    class X
    {
        public string A { get; set; }
        public int B { get; set; }

    }

    class Compa
    {
        public string id { get; set; }
        public string desc { get; set; }
        
    }

    public class CredentialCookie
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }

        public CredentialCookie() { }

        public CredentialCookie(string login, string password, string companyId, string branchId)
        {
            Login = login;
            Password = password;
            CompanyId = companyId;
            BranchId = branchId;
        }
    }

    class iop
    {
        public iop(string msg)
        {
            Console.WriteLine(msg);
        }

        public iop():this("Con parametros")
        {
            Console.WriteLine("Sin parametros");
        }
    }

    class io : iop
    {
        public string Hola { get; set; }
    }

    class Program
    {
        static void Main()
        {
            iop x = new io();            
            var type = x.GetType();            
        }
//        static void Main()
//        {
//            var data = "Data Source = 192.168.1.35:1521/UDEP2015; User Id = CN01; Password = CN01;";
//            using (var dataAccess = new O7DataAccess(data))
//            {
//                var parameter = new O7Parameter();
//                parameter.Add("COMPANY", "001");
//                parameter.Add("BRANCH", "001");
//                parameter.Add("YEAR", "2019");
//                dataAccess.ExecuteFunction<int>("ADVISORY_PERIOD.ACTIVATE_YEAR", parameter);
//            }
//        }

//        static void Main(string[] args)
//        {
//            var x= new iop();
//            Console.ReadKey();
//        }


//        static void Main(string[] args)
//        {
//            var x = "HOLA";
//            object z = "hola";
//            Console.WriteLine(x);
//            var s = z as string;
//            var u = $"{z}";
//            Console.WriteLine(z);
//            Console.WriteLine(u);
//            Console.WriteLine(s);
//            Console.ReadKey();
//        }

//        static void Main(string[] args)
//        {
//            var x = new List<X>();
//            x.Add(new X { A = "Serena y Satoshi", B = 100 });
//            x.Add(new X { A = "Dawn y Satoshi", B = 0 });
//            Console.WriteLine(O7JsonSerealizer.Serialize(x));
//        }

//        static void Main(string[] args)
//        {
//            test[] rest = null;
//            O7Connection x = null;
//            try
//            {
//                using (var data = new O7DataAccess(O7Provider.DataBaseConection("CN01", "CN04")))
//                {
//                    var ora = new OracleParameter();
//                    ora.OracleDbType = OracleDbType.RefCursor;
//                    ora.Direction = ParameterDirection.ReturnValue;
//                    var param = new OracleParameter("LOGIN", OracleDbType.Varchar2);
//                    param.Value = "CN01";
//                    param.Direction = ParameterDirection.Input;
//                    rest = data.ExecuteFunction("O7WEB_CONSULTAS.LISTAR_USUARIO",
//                            new O7Parameter(new[]
//                            {param}),
//                            reader =>
//                                new test
//                                {
//                                    Company = reader.GetValue<string>(0),
//                                    Branch = reader.GetValue<string>(1),
//                                    Description = reader.GetValue<string>(2)
//                                });
//                }
//            }
//            catch (OracleException e)
//            {
//                Console.WriteLine(e.Message);
//                throw;
//            }
//            
//        }

//        static void Main(string[] args)
//        {
//            dynamic x = new {Param = "oli", Param2 = "boli"};
//            O7Validator.ValidateStructure(x.GetType(), "Param", "Param2");
//        }

    }

    class test : O7Entity
    {
        public string Description { get; set; }
    }
}