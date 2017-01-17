// Create by Felix A. Bueno

using System.Collections.Generic;

namespace Angkor.O7Framework.Web.Model
{
    public class O7Menu
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public O7Menu(string id, string title, string observation, string url, string icon, string folder)
        {
            Id = id;
            Title = title;
            Observation = observation;
            Url = url;
            Icon = icon;
            Folder = folder;
        }

        public O7Menu()
        {
            
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Observation { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string Folder { get; set; }
        public List<O7Menu> Menus { get; set; }
    }
}