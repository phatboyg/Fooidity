namespace Fooidity.Configuration
{
    using System.Configuration;


    public class FooidityConfiguration :
        ConfigurationSection
    {
        [ConfigurationProperty("defaultState", DefaultValue = false, IsRequired = false)]
        public bool DefaultState
        {
            get { return (bool)this["defaultState"]; }
            set { this["defaultState"] = value; }
        }

        [ConfigurationProperty("features", IsDefaultCollection = false, IsRequired = false),
         ConfigurationCollection(typeof(FeatureStateElementCollection))]
        public FeatureStateElementCollection Features
        {
            get { return (FeatureStateElementCollection)this["features"]; }
            set { this["features"] = value; }
        }

        [ConfigurationProperty("contexts", IsDefaultCollection = false, IsRequired = false),
         ConfigurationCollection(typeof(ContextElementCollection))]
        public ContextElementCollection Contexts
        {
            get { return (ContextElementCollection)this["contexts"]; }
            set { this["contexts"] = value; }
        }
    }
}