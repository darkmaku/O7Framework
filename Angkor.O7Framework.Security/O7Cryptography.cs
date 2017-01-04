// Create by Felix A. Bueno

using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Text;
using Angkor.O7Framework.Common.Validator;

namespace Angkor.O7Framework.Utility
{
    public partial class O7Cryptography
    {
        private static readonly byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");
        private readonly Rfc2898DeriveBytes _key;

        public O7Cryptography(string key)
        {            
            Contract.Requires(ContractValidator.StringIsNotNullOrEmpty(key));
            _key = new Rfc2898DeriveBytes(key, _salt);
        }

        public string Encrypt(string value)
        {            
            Contract.Requires(ContractValidator.StringIsNotNullOrEmpty(value));
            Contract.Ensures(ContractValidator.StringIsNotNullOrEmpty(Contract.Result<string>()));
            var cryptoManaged = make_rijndael();
            var encryptor = cryptoManaged.CreateEncryptor(cryptoManaged.Key, cryptoManaged.IV);
            var result = encrypt_string(value, cryptoManaged, encryptor);
            cryptoManaged.Clear();
            return result;           
        }

        public string Decrypt(string value)
        {
            Contract.Requires(ContractValidator.StringIsNotNullOrEmpty(value));
            Contract.Ensures(ContractValidator.StringIsNotNullOrEmpty(Contract.Result<string>()));
            var cryptoManaged = make_rijndael();
            var bytes = Convert.FromBase64String(value);
            var result = decrypt_string(bytes, cryptoManaged);
            cryptoManaged.Clear();
            return result;
        }        
    }
}