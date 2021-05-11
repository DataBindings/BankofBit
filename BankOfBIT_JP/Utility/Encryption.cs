using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Utility
{
    /// <summary>
    /// This class is to handle encrypted batch files.
    /// </summary>
    public static class Encryption
    {
        /// <summary>
        /// Encrypts batch transaction files
        /// </summary>
        /// <param name="unencryptedFileName">the unencrypted file name.</param>
        /// <param name="encryptedFileName">the encrypted filename.</param>
        /// <param name="key"></param>
        public static void Encrypt(string unencryptedFileName, string encryptedFileName, string key)
        {
            FileStream decryptStream = new FileStream(unencryptedFileName, FileMode.Open, FileAccess.Read);
            FileStream encryptStream = new FileStream(encryptedFileName, FileMode.Create, FileAccess.Write);

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(key);

            ICryptoTransform desEncrypt = DES.CreateEncryptor();
            CryptoStream cryptoStream = new CryptoStream(encryptStream, desEncrypt, CryptoStreamMode.Write);

            byte[] bytearray = new byte[decryptStream.Length];
            decryptStream.Read(bytearray, 0, bytearray.Length);

            cryptoStream.Close();
            decryptStream.Close();
            encryptStream.Close();
        }

        /// <summary>
        /// Decrypts batch transaction files.
        /// </summary>
        /// <param name="encryptedFileName">the encrypted filename.</param>
        /// <param name="unencryptedFileName">the unencrypted file name.</param>
        /// <param name="key">The decryption key.</param>
        public static void Decrypt(string encryptedFileName, string unencryptedFileName, string key)
        {
            FileStream decryptStream = new FileStream(encryptedFileName, FileMode.Open, FileAccess.Read);

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(key);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(key);

            ICryptoTransform desDecrypt = DES.CreateDecryptor();

            CryptoStream cryptostreamDecr = new CryptoStream(decryptStream, desDecrypt, CryptoStreamMode.Read);

            StreamWriter swDecrypted = new StreamWriter(unencryptedFileName);
            swDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
            swDecrypted.Flush();
            swDecrypted.Close();
        }
    }
}
