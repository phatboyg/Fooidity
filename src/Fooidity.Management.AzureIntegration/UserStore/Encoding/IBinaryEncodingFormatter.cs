namespace Fooidity.Management.AzureIntegration.UserStore.Encoding
{
    public interface IBinaryEncodingFormatter
    {
        /// <summary>
        /// Format a byte array as an encoded string
        /// </summary>
        /// <param name="bytes">The byte array</param>
        /// <returns>Returns the encoded string</returns>
        string Format(byte[] bytes);
    }
}