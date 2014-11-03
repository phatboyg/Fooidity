namespace Fooidity.Management.AzureIntegration.UserStore.Encoding
{
    using System;
    using System.Text;


    public class Base32BinaryEncodingFormatter :
        IBinaryEncodingFormatter
    {
        const int Base32Size = 5;
        const int ByteSize = 8;
        const string LowerCaseChars = "abcdefghijklmnopqrstuvwxyz234567";
        const string UpperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        readonly string _chars;

        public Base32BinaryEncodingFormatter(bool upperCase = false)
        {
            _chars = upperCase ? UpperCaseChars : LowerCaseChars;
        }

        public Base32BinaryEncodingFormatter(string chars)
        {
            if (chars.Length != 32)
                throw new ArgumentException("The character string must be exactly 32 characters");

            _chars = chars;
        }

        public string Format(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException("bytes");

            if (bytes.Length == 0)
                return string.Empty;

            var builder = new StringBuilder(bytes.Length * ByteSize / Base32Size);

            int inputIndex = 0;
            int inputOffset = 0;

            byte outputIndex = 0;
            int outputOffset = 0;

            while (inputIndex < bytes.Length)
            {
                int bitsAvailableInByte = Math.Min(ByteSize - inputOffset, Base32Size - outputOffset);

                outputIndex <<= bitsAvailableInByte;
                outputIndex |= (byte)(bytes[inputIndex] >> (ByteSize - (inputOffset + bitsAvailableInByte)));

                inputOffset += bitsAvailableInByte;
                if (inputOffset >= ByteSize)
                {
                    inputIndex++;
                    inputOffset = 0;
                }

                outputOffset += bitsAvailableInByte;

                if (outputOffset >= Base32Size)
                {
                    outputIndex &= 0x1F;
                    builder.Append(_chars[outputIndex]);
                    outputOffset = 0;
                }
            }

            if (outputOffset > 0)
            {
                outputIndex <<= (Base32Size - outputOffset);
                outputIndex &= 0x1F;

                builder.Append(_chars[outputIndex]);
            }

            return builder.ToString();
        }
    }
}