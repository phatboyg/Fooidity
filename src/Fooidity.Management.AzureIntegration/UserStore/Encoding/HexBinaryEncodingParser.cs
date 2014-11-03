namespace Fooidity.Management.AzureIntegration.UserStore.Encoding
{
    using System;


    internal class HexBinaryEncodingParser :
        IBinaryEncodingParser
    {
        public byte[] Parse(string input)
        {
            if (input.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            var result = new byte[input.Length >> 1];

            for (int i = 0; i < input.Length >> 1; ++i)
                result[i] = (byte)((GetHexVal(input[i << 1]) << 4) + (GetHexVal(input[(i << 1) + 1])));

            return result;
        }

        public static int GetHexVal(char hex)
        {
            int val = hex & ~0x20;
            return val - (val < 58 ? 48 : 55);
        }
    }
}