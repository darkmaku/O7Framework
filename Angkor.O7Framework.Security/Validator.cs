// Create by Felix A. Bueno

using System;
using System.Reflection;

namespace Angkor.O7Framework.Security
{
    public class Validator
    {
        public static bool ValidateStructure(Type type, params string[] name)
        {
            var properties = type.GetProperties();
            for (var i = 0; i < name.Length; i++)            
                if (!ValidateName(name[i], properties))
                    return false;
            
            return true;
        }

        private static bool ValidateName(string name, PropertyInfo[] parameters)
        {            
            for (var i = 0; i < parameters.Length; i++)            
                if (name == parameters[i].Name)
                    return true;            

            return false;
        }
    }
}