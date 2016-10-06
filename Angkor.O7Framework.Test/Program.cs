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
    class Program
    {
        static void Main(string[] args)
        {
            test[] rest = null;
            O7Connection x = null;
            using (var data = new O7DataAccess(O7Provider.DataBaseConection("CN01", "CN01")))
            {
                var ora = new OracleParameter();
                ora.OracleDbType = OracleDbType.RefCursor;
                ora.Direction = ParameterDirection.ReturnValue;
                var param = new OracleParameter("LOGIN", OracleDbType.Varchar2);
                param.Value = "CN01";
                param.Direction = ParameterDirection.Input;
                rest = data.ExecuteFunction("O7WEB_CONSULTAS.LISTAR_USUARIO",
                        new O7Parameter(new[]
                        {param}),
                        reader =>
                            new test
                            {
                                Company = reader.GetValue<string>(0),
                                Branch = reader.GetValue<string>(1),
                                Description = reader.GetValue<string>(2)
                            });
            }
        }

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