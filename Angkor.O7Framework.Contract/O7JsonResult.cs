// Create by Felix A. Bueno

using System;

namespace Angkor.O7Framework.Contract
{
    public class O7JsonResult
    {
        public string Result { get; set; }
        public bool Success { get; set; }
        public Exception Exception { get; set; }
    }
}