// Created by Felix A. Bueno in 28/09/2016

using System.Configuration;

namespace Angkor.O7Framework.Data.Model
{
    public class O7DbConnection : ConfigurationSection
    {
        [ConfigurationProperty("provider")]
        public string Provider
        {
            get { return (string) base["provider"]; }
            set { base["provider"] = value; }
        }

        [ConfigurationProperty("server")]
        public string Server
        {
            get { return (string) base["server"]; }
            set { base["server"] = value; }
        }
    }
}