namespace Fooidity.Management.AzureIntegration.UserStore.Encoding
{
    public class ZBase32BinaryEncodingParser :
        Base32BinaryEncodingParser
    {
        const string ConvertChars = "ybndrfg8ejkmcpqxot1uwisza345h769YBNDRFG8EJKMCPQXOT1UWISZA345H769";
        const string TransposeChars = "ybndrfg8ejkmcpqx0tlvwis2a345h769YBNDRFG8EJKMCPQX0TLVWIS2A345H769";

        public ZBase32BinaryEncodingParser(bool handleTransposedCharacters = false)
            : base(handleTransposedCharacters ? ConvertChars + TransposeChars : ConvertChars)
        {
        }
    }
}