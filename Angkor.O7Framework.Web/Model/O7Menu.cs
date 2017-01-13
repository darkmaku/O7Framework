// Create by Felix A. Bueno

using System.Collections.Generic;

namespace Angkor.O7Framework.Web.Model
{
    public class O7Menu
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Observation { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string Folder { get; set; }
        public List<O7Menu> Menus { get; set; }        
    }
}