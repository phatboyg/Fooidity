namespace Fooidity.Management.Queries
{
    public class GetApplicationByKey :
        IGetApplicationByKey
    {
        public GetApplicationByKey(string key)
        {
            Key = key;
        }

        public string Key { get; set; }
    }
}