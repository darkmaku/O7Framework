using System;
using System.Configuration;

namespace Angkor.O7Framework.Utility
{
    public class O7Settings : ConfigurationSection
    {        
        private  static  O7Settings _settings = ConfigurationManager.GetSection ("O7Settings") as O7Settings;

        public static O7Settings Settings => _settings;
        

        [ConfigurationProperty("name", IsRequired = false)]        
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }
    }
}
