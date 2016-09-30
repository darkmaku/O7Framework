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
                rest =
                    data.ExecuteFunction("O7WEB_CONSULTAS.LISTAR_USUARIO",
                        new O7Parameter(new[]
                        {
                            new OracleParameter("CODCIA", OracleDbType.Varchar2, 3, "001", ParameterDirection.Input),
                            new OracleParameter("CODSUC", OracleDbType.Varchar2, 3, "001", ParameterDirection.Input)
                        }),O7DataType.RefCursor,
                        reader =>
                            new test
                            {
                                Company = reader.GetString(0),
                                Branch = reader.GetString(1)
                            });
            }
        }
    }

    class test : O7Entity
    {
        public string Description { get; set; }
    }
}