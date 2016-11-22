﻿// Create by Felix A. Bueno

using System;

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
            string[] parameters = _parameterUrl.Split ('&');
            for (var i = 0; i < parameters.Length; i++)
            {
                string parameter = parameters[i];
                if(!parameter.Contains (name)) continue;
                string[] parameterSplit = parameter.Split ('=');
                return parameterSplit[1];
            }
            return string.Empty;
        }
    }
}