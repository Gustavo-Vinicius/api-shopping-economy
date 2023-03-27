using System.Security.Cryptography;
using System.Text;

namespace shopping_economyShared.Utils
{
    public static class Cryptography
    {
        public static string EncryptToSha256(string value)
        {
            var crypt = SHA256.Create();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(value));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}