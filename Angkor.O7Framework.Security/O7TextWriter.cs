// Create by Felix A. Bueno

using System.IO;

namespace Angkor.O7Framework.Utility
{
    public class O7TextWriter
    {
        private string _path;
        private string _file;
        private string _completePath;

        public O7TextWriter(string path, string name, string extension)
        {
            _path = path;
            _file = $"{name}.{extension}";
            _completePath = $"{_path}/{_file}";
            if (!Directory.Exists(_path)) Directory.CreateDirectory(_path);
            if (!File.Exists(_completePath)) File.Create(_completePath);
        }

        public bool Empty => new FileInfo(_completePath).Length == 0;

        public void Write(string text)
        {
            using (var writer = new StreamWriter(_completePath, true))
                writer.Write(text);
        }               
    }
}