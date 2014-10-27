namespace Fooidity.Configuration
{
    using System.Configuration;


    public class ContextElement :
        ConfigurationElement
    {
        [ConfigurationProperty("type", DefaultValue = "", IsRequired = false)]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("instances", IsDefaultCollection = true, IsRequired = false),
         ConfigurationCollection(typeof(ContextInstanceElementCollection))]
        public ContextInstanceElementCollection Instances
        {
            get { return (ContextInstanceElementCollection)this["instances"]; }
            set { this["instances"] = value; }
        }
    }
}