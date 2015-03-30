using System;

namespace TeaCrypto
{
    /// <summary>
    /// Summary description for XTea.
    /// </summary>
    public class XTea
    {
        // Ctor
        public XTea()
        {
        }
        /// <summary>
        /// Encrypt the data using a prespecified key
        /// </summary>
        /// <param name="Data">string DecryptedData</param>
        /// <param name="Key">string Key</param>
        /// <returns>string EncryptedData</returns>
        public string EncryptString(string Data, string Key)
        {
            if (Data.Length == 0)
                throw new ArgumentException("Data must be at least 1 character in length.");

            uint[] formattedKey = FormatKey(Key);

            if (Data.Length % 2 != 0) Data += '\0'; // Make sure array is even in length.		
            byte[] dataBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(Data);

            string cipher = string.Empty;
            uint[] tempData = new uint[2];
            for (int i = 0; i < dataBytes.Length; i += 2)
            {
                tempData[0] = dataBytes[i];
                tempData[1] = dataBytes[i + 1];
                code(tempData, formattedKey);
                cipher += Util.ConvertUIntToString(tempData[0]) + Util.ConvertUIntToString(tempData[1]);
            }

            return cipher;
        }
        /// <summary>
        /// Decrypt the data using a prespecified key
        /// </summary>
        /// <param name="Data">string EncryptedData</param>
        /// <param name="Key">string Key</param>
        /// <returns>string DecryptedData</returns>
        public string Decrypt(string Data, string Key)
        {
            uint[] formattedKey = FormatKey(Key);

            int x = 0;
            uint[] tempData = new uint[2];
            byte[] dataBytes = new byte[Data.Length / 8 * 2];
            for (int i = 0; i < Data.Length; i += 8)
            {
                tempData[0] = Util.ConvertStringToUInt(Data.Substring(i, 4));
                tempData[1] = Util.ConvertStringToUInt(Data.Substring(i + 4, 4));
                decode(tempData, formattedKey);
                dataBytes[x++] = (byte)tempData[0];
                dataBytes[x++] = (byte)tempData[1];
            }
            string decipheredString = System.Text.ASCIIEncoding.ASCII.GetString(dataBytes, 0, dataBytes.Length);
            if (decipheredString[decipheredString.Length - 1] == '\0')
                decipheredString = decipheredString.Substring(0, decipheredString.Length - 1);
            return decipheredString;
        }

        public uint[] FormatKey(string Key)
        {
            if (Key.Length == 0)
                throw new ArgumentException("Key must be between 1 and 16 characters in length");

            Key = Key.PadRight(16, ' ').Substring(0, 16); // Ensure that the key is 16 chars in length.
            uint[] formattedKey = new uint[4];

            // Get the key into the correct format for TEA usage.
            int j = 0;
            for (int i = 0; i < Key.Length; i += 4)
                formattedKey[j++] = Util.ConvertStringToUInt(Key.Substring(i, 4));

            return formattedKey;
        }

        #region XTea Algorithm
        private void code(uint[] v, uint[] k)
        {
            uint y = v[0];
            uint z = v[1];
            uint sum = 0;
            uint delta = 0x9E3779B9;
            uint n = 32;

            while (n-- > 0)
            {
                y += (z << 4 ^ z >> 5) + z ^ sum + k[sum & 3];
                sum += delta;
                z += (y << 4 ^ y >> 5) + y ^ sum + k[sum >> 11 & 3];
            }

            v[0] = y;
            v[1] = z;
        }

        private void decode(uint[] v, uint[] k)
        {
            uint y = v[0];
            uint z = v[1];
            uint sum = 0xC6EF3720;
            uint delta = 0x9E3779B9;
            uint n = 32;

            while (n-- > 0)
            {
                z -= (y << 4 ^ y >> 5) + y ^ sum + k[sum >> 11 & 3];
                sum -= delta;
                y -= (z << 4 ^ z >> 5) + z ^ sum + k[sum & 3];
            }

            v[0] = y;
            v[1] = z;
        }
        #endregion

    }
}
