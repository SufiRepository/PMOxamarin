using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PMOApp.Models
{
    public class decryptencryptModel
    {
        public static string FromBase64String(string _string)
        {
            UTF8Encoding utf8encoder = new UTF8Encoding();
            byte[] inputInBytes = Convert.FromBase64String(_string);
            return utf8encoder.GetString(inputInBytes);
        }

        public static string ConvertTo64String(string _string)
        {
            UTF8Encoding utf8encoder = new UTF8Encoding();
            byte[] encodedBytes = utf8encoder.GetBytes(_string);
            return Convert.ToBase64String(encodedBytes);
        }

        public static string Encrypt(string plainText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
        {
            byte[] initVectorBytes;
            initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes;
            saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes;
            plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password;
            password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
            // Dim password As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations)
            byte[] keyBytes;
            keyBytes = password.GetBytes((int)(keySize / (double)8));
            RijndaelManaged symmetricKey;
            symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor;
            encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream;
            memoryStream = new MemoryStream();
            CryptoStream cryptoStream;
            cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes;
            cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText;
            cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }

        public static string Decrypt(string cipherText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
        {
            byte[] initVectorBytes;
            initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes;
            saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes;
            cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password;
            password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes;
            keyBytes = password.GetBytes((int)(keySize / (double)8));
            RijndaelManaged symmetricKey;
            symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor;
            decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream;
            memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream;
            cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes;
            plainTextBytes = new byte[cipherTextBytes.Length + 1 - 1 + 1];
            int decryptedByteCount;
            decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            string plainText;
            plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            return plainText;
        }

        public static string encrypt(string inputString)
        {
            return decryptencryptModel.Encrypt(inputString, "Pas5pr@se", "s@1tValue", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);
        }

        public static string decrypt(string inputString)
        {
            return decryptencryptModel.Decrypt(inputString, "Pas5pr@se", "s@1tValue", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);
        }
    }
}
