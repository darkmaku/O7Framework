// Create by Felix A. Bueno

using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Angkor.O7Framework.Utility
{
    public class O7Cryptography
    {
        private static readonly byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");
        private readonly Rfc2898DeriveBytes _key;

        public O7Cryptography(string key)
        {
            //if(string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            Contract.Requires(UtilityHelper.ValidStringParameter(key));
            _key = new Rfc2898DeriveBytes(key, _salt);
        }

        public string Encrypt(string value)
        {
            //if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));
            Contract.Requires(UtilityHelper.ValidStringParameter(value));
            Contract.Ensures(UtilityHelper.ValidStringResult(Contract.Result<string>()));
            var cryptoManaged = make_rijndael();
            var encryptor = cryptoManaged.CreateEncryptor(cryptoManaged.Key, cryptoManaged.IV);
            var result = encrypt_string(value, cryptoManaged, encryptor);
            cryptoManaged.Clear();
            return result;           
        }

        public string Decrypt(string value)
        {
            //if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));
            Contract.Requires(UtilityHelper.ValidStringParameter(value));
            Contract.Ensures(UtilityHelper.ValidStringResult(Contract.Result<string>()));
            var cryptoManaged = make_rijndael();
            var bytes = Convert.FromBase64String(value);
            var result = decrypt_string(bytes, cryptoManaged);
            cryptoManaged.Clear();
            return result;
        }

        private string decrypt_string(byte[] bytes, SymmetricAlgorithm cryptoManaged)
        {
            Contract.Ensures(UtilityHelper.ValidStringResult(Contract.Result<string>()));
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
            Contract.Ensures(UtilityHelper.ValidStringResult(Contract.Result<string>()));
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
            Contract.Requires(UtilityHelper.ValidStream(s));
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