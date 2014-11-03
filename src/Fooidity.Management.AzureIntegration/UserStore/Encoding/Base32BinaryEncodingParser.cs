namespace Fooidity.Management.AzureIntegration.UserStore.Encoding
{
    using System;


    public class Base32BinaryEncodingParser :
        IBinaryEncodingParser
    {
        const int Base32ByteSize = 5;
        const int ByteSize = 8;
        const string ConvertChars = "abcdefghijklmnopqrstuvwxyz234567ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        readonly string _chars;

        public Base32BinaryEncodingParser(string chars)
        {
            if (chars.Length % 32 != 0)
                throw new ArgumentException("The characters must be a multiple of 32");

            _chars = chars;
        }

        public Base32BinaryEncodingParser()
        {
            _chars = ConvertChars;
        }

        public byte[] Parse(string input)
        {
            if (input == null)
                return null;

            if (string.IsNullOrWhiteSpace(input))
                return new byte[0];

            var bytes = new byte[input.Length * Base32ByteSize / ByteSize];
            if (bytes.Length == 0)
                throw new ArgumentException("Invalid input string (insufficient data)");

            int inputIndex = 0;
            int inputSubIndex = 0;
            int outputIndex = 0;
            int outputSubIndex = 0;

            while (outputIndex < bytes.Length)
            {
                int currentBase32Byte = _chars.IndexOf(input[inputIndex]);
                if (currentBase32Byte < 0)
                    throw new ArgumentException(string.Format("Invalid input string (unknown character \'{0}\')", input[inputIndex]));

                currentBase32Byte %= 32;

                int bitsAvailableInByte = Math.Min(Base32ByteSize - inputSubIndex, ByteSize - outputSubIndex);

                bytes[outputIndex] <<= bitsAvailableInByte;

                bytes[outputIndex] |= (byte)(currentBase32Byte >> (Base32ByteSize - (inputSubIndex + bitsAvailableInByte)));

                outputSubIndex += bitsAvailableInByte;
                if (outputSubIndex >= ByteSize)
                {
                    outputIndex++;
                    outputSubIndex = 0;
                }

                inputSubIndex += bitsAvailableInByte;
                if (inputSubIndex >= Base32ByteSize)
                {
                    inputIndex++;
                    inputSubIndex = 0;
                }
            }

            return bytes;
        }
    }
}