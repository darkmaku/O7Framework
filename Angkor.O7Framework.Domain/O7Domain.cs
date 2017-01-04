// Create by Felix A. Bueno

using System;
using Angkor.O7Framework.Common;
using Angkor.O7Framework.Infraestructure;

namespace Angkor.O7Framework.Domain
{
    public class O7Domain : O7AbstractDomain
    {
        public override void OnEntry(O7Parameter[] parameters)
        {
            foreach (var parameter in parameters)
            {
                Console.WriteLine("Name: " + parameter.Name);
                Console.WriteLine("Value: " + parameter.Value);
            }
        }

        public override void OnExit(O7Parameter[] parameters)
        {
            foreach (var parameter in parameters)
            {
                Console.WriteLine("Name: " + parameter.Name);
                Console.WriteLine("Value: " + parameter.Value);
            }
            //SetReturnValue("oliwi");
        }

        public override void OnException(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}