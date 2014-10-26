namespace Fooidity.Configuration
{
    using System.Configuration;


    public class FeatureStateElement :
        ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true)]
        public string Id
        {
            get { return (string)this["id"]; }
            set { this["id"] = value; }
        }

        [ConfigurationProperty("type", DefaultValue = "", IsRequired = false)]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }


        [ConfigurationProperty("enabled", DefaultValue = false, IsRequired = false)]
        public bool Enabled
        {
            get { return (bool)this["enabled"]; }
            set { this["enabled"] = value; }
        }
    }
}