// Create by Felix A. Bueno
using System.IO;

namespace Angkor.O7Framework.Utility
{
    public class O7TextWriter
    {
        private readonly string _completePath;

        public O7TextWriter(string path, string name, string extension)
        {            
            _completePath = $"{path}\\{name}.{extension}";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            if (!File.Exists(_completePath)) File.Create(_completePath);
        }

        public bool Empty => new FileInfo(_completePath).Length == 0;

        public void Write(string text)
        {
            using (var writer = File.AppendText(_completePath))
                writer.Write(text);
        }               
    }
}