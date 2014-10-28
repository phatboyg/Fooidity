namespace Fooidity.Configuration
{
    using System.Configuration;


    [ConfigurationCollection(typeof(ContextInstanceElement),
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ContextInstanceElementCollection
        : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        public ContextInstanceElement this[int index]
        {
            get { return (ContextInstanceElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);
                base.BaseAdd(index, value);
            }
        }
        protected override string ElementName
        {
            get { return "instance"; }
        }

        public new ContextInstanceElement this[string name]
        {
            get { return (ContextInstanceElement)BaseGet(name); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ContextInstanceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var instanceElement = element as ContextInstanceElement;

            return instanceElement.Key;
        }
    }
}