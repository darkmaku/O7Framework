// Create by Felix A. Bueno

using System;
using System.Configuration;
using Angkor.O7Framework.Components.Model;
using Angkor.O7Framework.Utility;

namespace Angkor.O7Framework.Components
{
    public class O7Logger
    {
        private readonly string _name;
        private readonly O7TextWriter _textWriter;
        private readonly Type _definitionCaller;

        public O7Logger(string name, Type definitionCaller)
        {
            _name = name;
            _definitionCaller = definitionCaller;
            _textWriter = build_text_writer();
        }

        public void AppendError(string subject)
        {
            var currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            var assemblyName = _definitionCaller.Assembly.FullName;
            var className = _definitionCaller.FullName;
            var objectTransfer = new LogRow(currentDate, _name, assemblyName, className, subject);
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