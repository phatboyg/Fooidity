namespace Fooidity.Management.AzureIntegration.UserStore.Encoding
{
    public class HexBinaryEncodingFormatter :
        IBinaryEncodingFormatter
    {
        readonly int _alpha;

        public HexBinaryEncodingFormatter(bool upperCase = false)
        {
            _alpha = upperCase ? 'A' : 'a';
        }

        public string Format(byte[] bytes)
        {
            var result = new char[bytes.Length * 2];

            int offset = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                byte value = bytes[i];
                result[offset++] = HexToChar(value >> 4, _alpha);
                result[offset++] = HexToChar(value, _alpha);
            }

            return new string(result, 0, result.Length);
        }

        static char HexToChar(int value, int alpha)
        {
            value = value & 0xf;
            return (char)((value > 9) ? value - 10 + alpha : value + 0x30);
        }
    }
}