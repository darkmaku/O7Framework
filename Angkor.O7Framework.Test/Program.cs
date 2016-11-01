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
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Framework.Test
{
    class X
    {
        public string A { get; set; }
        public int B { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var x = "{\"A\":\"Serena y Satoshi\",\"B\":100}";
            var y = O7JsonSerealizer.Deserialize<X>(x);
            Console.WriteLine(x.Remove(0, 1).Remove(x.Length-2, 1));
        }

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