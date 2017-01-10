// Create by Felix A. Bueno
namespace Angkor.O7Framework.Components.Model
{
    public class LogRow
    {
        public string Date { get; set; }
        public string User { get; set; }
        public string Assembly { get; set; }
        public string Class { get; set; }
        public string Message { get; set; }

        public LogRow(string date, string user, string assembly, string @class, string message)
        {
            Date = date;
            User = user;
            Assembly = assembly;
            Class = @class;
            Message = message;
        }        
    }
}