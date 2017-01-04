﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angkor.O7Framework.Common.Validator
{
    public static class StringsValidator
    {
        public static bool AllNotNull(params string[] strings)
        {
            return strings.All(s => s != null);
        }
    }
}
