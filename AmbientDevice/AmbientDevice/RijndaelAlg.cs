using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace AmbientDevice
{
    public static class RijndaelAlg
    {

        public static string encryptString(String plainMessage)
        {

            string fecha = DateTime.Now.ToString("d/M/yyyy");
            var temp = MD5.CalculateMD5Hash(fecha);
            Rijndael RijndaelAlg = Rijndael.Create();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         RijndaelAlg.CreateEncryptor(Encoding.ASCII.GetBytes(temp), Encoding.ASCII.GetBytes(temp.Substring(0, 16))),
                                                         CryptoStreamMode.Write);
            byte[] plainMessageBytes = UTF8Encoding.UTF8.GetBytes(plainMessage);
            cryptoStream.Write(plainMessageBytes, 0, plainMessageBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherMessageBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherMessageBytes);
        }

        public static string decryptString(String encryptedMessage)
        {
            string fecha = DateTime.Now.ToString("d/M/yyyy");
            var temp = MD5.CalculateMD5Hash(fecha);
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedMessage);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            Rijndael RijndaelAlg = Rijndael.Create();
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         RijndaelAlg.CreateDecryptor(Encoding.ASCII.GetBytes(temp), Encoding.ASCII.GetBytes(temp.Substring(0, 15))),
                                                         CryptoStreamMode.Read);
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}
