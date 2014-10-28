namespace Fooidity.Configuration
{
    using System.Configuration;


    [ConfigurationCollection(typeof(ContextElement),
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ContextElementCollection
        : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        public ContextElement this[int index]
        {
            get { return (ContextElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);
                base.BaseAdd(index, value);
            }
        }

        protected override string ElementName
        {
            get { return "context"; }
        }

        public new ContextElement this[string name]
        {
            get { return (ContextElement)BaseGet(name); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ContextElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var contextElement = element as ContextElement;

            return contextElement.Id;
        }
    }
}