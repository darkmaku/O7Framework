// Create by Felix A. Bueno

using System;
using System.Configuration;
using Angkor.O7Framework.Components.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Security;

namespace Angkor.O7Framework.Components
{
    public class O7Logger
    {
        private readonly O7Principal _credential;
        private readonly O7TextWriter _textWriter;
        private readonly Type _definitionCaller;

        public O7Logger(O7Principal credential, Type definitionCaller)
        {
            _credential = credential;
            _definitionCaller = definitionCaller;
            _textWriter = build_text_writer();
        }

        public void AppendError(string subject)
        {
            var currentDate = DateTime.Now;
            var assemblyName = _definitionCaller.Assembly.FullName;
            var className = _definitionCaller.FullName;
            var objectTransfer = new
            {
                current_date = currentDate,
                user_name = _credential.Name,
                assembly = assemblyName,
                class_name = className,
                exception_message = subject
            };
            var serializedObject = O7JsonSerealizer.Serialize(objectTransfer);
            var text = _textWriter.Empty ? serializedObject : $",{serializedObject}";
            _textWriter.Write(text);
        }

        private O7TextWriter build_text_writer()
        {
            var connection = (O7File)ConfigurationManager.GetSection("O7File");
            return new O7TextWriter(connection.Path, connection.Name, connection.Extension);
        }
    }
}