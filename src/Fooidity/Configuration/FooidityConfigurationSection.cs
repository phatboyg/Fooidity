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
    }
}