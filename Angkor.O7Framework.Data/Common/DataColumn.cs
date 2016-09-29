// Created by Felix A. Bueno in 29/09/2016

using System;

namespace Angkor.O7Framework.Data.Common
{
    [AttributeUsage (AttributeTargets.Property)]
    public class DataColumn : Attribute
    {
        public int Index { get; }
        public string Type { get; }

        public DataColumn (int index, string type)
        {
            Index = index;
            Type = type;
        }
    }
}