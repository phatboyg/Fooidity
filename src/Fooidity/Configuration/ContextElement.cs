namespace Fooidity.Configuration
{
    using System.Configuration;


    public class ContextElement :
        ConfigurationElement
    {
        [ConfigurationProperty("id", DefaultValue = "", IsRequired = false)]
        public string Id
        {
            get { return (string)this["id"]; }
            set { this["id"] = value; }
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