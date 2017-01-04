// Create by Felix A. Bueno

using System;
using System.IO;
using System.Security.Cryptography;

namespace Angkor.O7Framework.Utility
{
    public partial class O7Cryptography
    {
        private string decrypt_string(byte[] bytes, SymmetricAlgorithm cryptoManaged)
        {
            using (var memoryStream = new MemoryStream(bytes))
            {
                cryptoManaged.IV = read_bytes(memoryStream);
                var decryptor = cryptoManaged.CreateDecryptor(cryptoManaged.Key, cryptoManaged.IV);

                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                using (var streamReader = new StreamReader(cryptoStream)) return streamReader.ReadToEnd();
            }
        }

        private string encrypt_string(string value, SymmetricAlgorithm cryptoManaged, ICryptoTransform cryptoTransform)
        {
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(BitConverter.GetBytes(cryptoManaged.IV.Length), 0, sizeof(int));
                memoryStream.Write(cryptoManaged.IV, 0, cryptoManaged.IV.Length);

                using (var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                using (var streamWriter = new StreamWriter(cryptoStream)) streamWriter.Write(value);

                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        private RijndaelManaged make_rijndael()
        {
            var cryptoManaged = new RijndaelManaged();
            cryptoManaged.Key = _key.GetBytes(cryptoManaged.KeySize / 8);
            return cryptoManaged;
        }

        private static byte[] read_bytes(Stream s)
        {
            var rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
                throw new SystemException("Stream did not contain properly formatted byte array");

            var buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
                throw new SystemException("Did not read byte array properly");

            return buffer;
        }
    }
}