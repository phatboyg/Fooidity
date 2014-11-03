namespace Fooidity.Management.AzureIntegration.UserStore
{
    using System;


    [AttributeUsage(AttributeTargets.Property)]
    public class NonSerializedTableStoreAttribute : 
        Attribute
    {
    }
}