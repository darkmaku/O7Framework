using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Angkor.O7Framework.Data.Common;
using Angkor.O7Framework.Data.Exception;
using Angkor.O7Framework.Data.Utility;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Angkor.O7Framework.Data
{
    public struct O7JsonResult
    {
        public string JsonResult { get; set; }
        public bool Valid { get; set; }
    }

}