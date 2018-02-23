// Solution: O7Framework
// Owner: FBUENO
// Date: 23 - 02 - 2018

using System.Configuration;

namespace Angkor.O7Framework.Web.Utility
{
    public class O7WebAppstart : ConfigurationSection
    {
        [ConfigurationProperty("namespace")]
        public string Namespace
        {
            get => (string)base["namespace"];
            set => base["namespace"] = value;
        }

        [ConfigurationProperty("action")]
        public string Action
        {
            get => (string)base["action"];
            set => base["action"] = value;
        }

        [ConfigurationProperty("controller")]
        public string Controller
        {
            get => (string)base["controller"];
            set => base["controller"] = value;
        }
    }
}