// Solution: O7Framework
// Owner: FBUENO
// Date: 26 - 02 - 2018
namespace Angkor.O7Framework.Utility
{
    public static class CryptographyExtension
    {
        public static string Decrypt(this string value)
        {
            var cryptography = new O7Cryptography();
            return cryptography.Decrypt(value);
        }
    }
}