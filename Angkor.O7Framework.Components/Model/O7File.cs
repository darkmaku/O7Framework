// Create by Felix A. Bueno

using System.Configuration;

namespace Angkor.O7Framework.Components.Model
{
    public class O7File : ConfigurationSection
    {
        [ConfigurationProperty("path")]
        public string Path
        {
            get { return (string)base["path"]; }
            set { base["path"] = value; }
        }

        [ConfigurationProperty("name")]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("extension")]
        public string Extension
        {
            get { return (string)base["extension"]; }
            set { base["extension"] = value; }
        }
    }
}