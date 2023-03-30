using System;
using System.Security.Cryptography;
using System.Text;

namespace WebTuyenDung.Helper
{
    public static class CryptographicHelper
    {
        public static string Sha256(this string raw)
        {
            var bytes = SHA256.HashData(raw.ToBytes());
            return Convert.ToHexString(bytes);
        }

        public static byte[] ToBytes(this string content)
        {
            return Encoding.UTF8.GetBytes(content);
        }
    }
}
