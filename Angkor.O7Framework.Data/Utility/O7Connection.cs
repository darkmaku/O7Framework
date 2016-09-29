// Created by Felix A. Bueno in 28/09/2016

using System.Configuration;

namespace Angkor.O7Framework.Data.Utility
{
    public class O7Connection : ConfigurationSection
    {
        [ConfigurationProperty ("provider", IsRequired = true)]
        public string Provider => (string) this["provider"];

        [ConfigurationProperty ("server", IsRequired = true)]
        public string Server => (string) this["server"];
    }
}