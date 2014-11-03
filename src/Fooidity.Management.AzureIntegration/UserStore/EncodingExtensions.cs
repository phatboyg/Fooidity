namespace Fooidity.Management.AzureIntegration.UserStore
{
    using System.Security.Cryptography;
    using Encoding;


    static class EncodingExtensions
    {
        public static string ToSha256(this string plainText)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            using (var hasher = new SHA256Managed())
            {
                byte[] hash = hasher.ComputeHash(bytes, 0, bytes.Length);

                return hash.ToBase32();
            }
        }

        /// <summary>
        /// Encode the byte array as a ZBase32 string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToBase32(this byte[] data)
        {
            return Cached.Formatter.Format(data);
        }


        static class Cached
        {
            internal static readonly IBinaryEncodingFormatter Formatter = new ZBase32BinaryEncodingFormatter();
        }
    }
}