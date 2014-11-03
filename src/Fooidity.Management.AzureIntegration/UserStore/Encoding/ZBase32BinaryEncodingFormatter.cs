namespace Fooidity.Management.AzureIntegration.UserStore.Encoding
{
    public class ZBase32BinaryEncodingFormatter :
        Base32BinaryEncodingFormatter
    {
        // taken from analysis done at http://philzimmermann.com/docs/human-oriented-base-32-encoding.txt
        const string LowerCaseChars = "ybndrfg8ejkmcpqxot1uwisza345h769";
        const string UpperCaseChars = "YBNDRFG8EJKMCPQXOT1UWISZA345H769";

        public ZBase32BinaryEncodingFormatter(bool upperCase = false)
            : base(upperCase ? UpperCaseChars : LowerCaseChars)
        {
        }
    }
}