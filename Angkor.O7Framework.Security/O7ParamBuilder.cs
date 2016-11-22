﻿// Create by Felix A. Bueno

namespace Angkor.O7Framework.Utility
{
    public class O7ParamBuilder
    {
        private string _parameterUrl;

        public O7ParamBuilder()
        {
            _parameterUrl = string.Empty;
        }

        public O7ParamBuilder(string parameterUrl)
        {
            _parameterUrl = parameterUrl;            
        }

        public void AppendParameter(string name, string value)
        {
            _parameterUrl = string.Concat(_parameterUrl, string.IsNullOrEmpty(_parameterUrl) ? $"{name}={value}" : $"&{name}={value}");
        }

        public string GetParameterValue(string name)
        {
            
        }
    }
}