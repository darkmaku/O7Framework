using System.ComponentModel;
using System.IO;
using  Angkor.O7Framework.Common.Validator;
using System;
using System.Collections;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Text;
namespace Angkor.O7Framework.Utility
{
    public static class UtilityHelper
    {
        public static bool ValidStringParameter(params string[] strings)
        {
            return StringsValidator.AllNotNull(strings);
        }

        public static bool ValidStringResult(params string[] strings)
        {
            return StringsValidator.AllNotNull(strings);
        }

        public static bool ValidStream(Stream s)
        {
            var rawLength = new byte[sizeof(int)];
            return s.Read(new byte[sizeof (int)], 0, rawLength.Length) != rawLength.Length;
        }

        public static bool ValidTResultResult(object r) => r != null;
        
    }
}