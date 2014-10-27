namespace Fooidity.Configuration
{
    using System.Configuration;


    public class ContextInstanceElement :
        ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("features", IsDefaultCollection = true, IsRequired = false),
         ConfigurationCollection(typeof(FeatureStateElementCollection))]
        public FeatureStateElementCollection Features
        {
            get { return (FeatureStateElementCollection)this["features"]; }
            set { this["features"] = value; }
        }
    }
}