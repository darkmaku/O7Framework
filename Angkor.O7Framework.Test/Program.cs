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
using Angkor.O7Framework.Security;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Framework.Test
{
    class Program
    {
//        static void Main(string[] args)
//        {
//            test[] rest = null;
//            O7Connection x = null;
//            using (var data = new O7DataAccess(O7Provider.DataBaseConection("CN01", "CN01")))
//            {
//                var ora = new OracleParameter();
//                ora.OracleDbType = OracleDbType.RefCursor;
//                ora.Direction = ParameterDirection.ReturnValue;
//                rest =
//                    data.ExecuteFunction("O7WEB_CONSULTAS.LISTAR_USUARIO",
//                        new O7Parameter(new[]
//                        {
//                            new OracleParameter("LOGIN", OracleDbType.Varchar2, 4, "CN01", ParameterDirection.Input)                            
//                        }),O7DataType.RefCursor,
//                        reader =>
//                            new test
//                            {
//                                Company = reader.GetString(0),
//                                Branch = reader.GetString(1),
//                                Description = reader.GetString(2)
//                            });
//            }
//        }

        static void Main(string[] args)
        {
            dynamic x = new {Param = "oli", Param2 = "boli"};
            Validator.ValidateStructure(x.GetType(), "Param", "Param2");
        }

    }

    class test : O7Entity
    {
        public string Description { get; set; }
    }
}