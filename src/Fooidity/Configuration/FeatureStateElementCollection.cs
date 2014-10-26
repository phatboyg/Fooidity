namespace Fooidity.Configuration
{
    using System.Configuration;


    [ConfigurationCollection(typeof(FeatureStateElement),
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class FeatureStateElementCollection
        : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        public FeatureStateElement this[int index]
        {
            get { return (FeatureStateElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);
                base.BaseAdd(index, value);
            }
        }

        protected override string ElementName
        {
            get { return "feature"; }
        }

        public new FeatureStateElement this[string name]
        {
            get { return (FeatureStateElement)BaseGet(name); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new FeatureStateElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var featureStateElement = element as FeatureStateElement;

            return featureStateElement.Id;
        }
    }
}