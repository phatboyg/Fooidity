namespace Fooidity.Management.AzureIntegration.UserStore.Encoding
{
    public interface IBinaryEncodingParser
    {
        /// <summary>
        /// Parse the input string into a byte array
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The byte array (if the input string is null, null is returned)</returns>
        byte[] Parse(string input);
    }
}