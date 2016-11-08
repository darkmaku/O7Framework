using System.Configuration;

namespace Angkor.O7Framework.Web.Utility
{
    public class O7WebSource : ConfigurationSection
    {
        [ConfigurationProperty("address")]
        public string Address
        {
            get { return (string)base["address"]; }
            set { base["address"] = value; }
        }

        [ConfigurationProperty("port")]
        public string Port
        {
            get { return (string)base["port"]; }
            set { base["port"] = value; }
        }

        [ConfigurationProperty("source")]
        public string Source
        {
            get { return (string)base["source"]; }
            set { base["source"] = value; }
        }
    }
}
