using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Security;
using System.IO;

namespace AccountabilityNotePad
{
    class Cryptograph
    {

        public static string GenerateKey()
        {
            // Create an instance of Symetric Algorithm. Key and IV is generated automatically.
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();

            // Use the Automatically generated key for Encryption. 
            return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
        }

        public static void EncryptFile(string StringToEncrypt, string OutPutFilePath, string sKey)
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            FileStream OStream = new FileStream(OutPutFilePath, FileMode.OpenOrCreate);
            CryptoStream cryptostream = new CryptoStream(OStream, desencrypt, CryptoStreamMode.Write);
            cryptostream.Write(ASCIIEncoding.ASCII.GetBytes(StringToEncrypt), 0, ASCIIEncoding.ASCII.GetBytes(StringToEncrypt).Length);
            cryptostream.Close();
        }

        public static string DecryptFile(string EncryptedStringPath, string sKey)
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            //A 64 bit key and IV is required for this provider.
            //Set secret key For DES algorithm.
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //Set initialization vector.
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            //Create a file stream to read the encrypted file back.
            FileStream fsread = new FileStream(EncryptedStringPath, FileMode.Open, System.IO.FileAccess.Read);
            //Create a DES decryptor from the DES instance.
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            //Create crypto stream set to read and do a 
            //DES decryption transform on incoming bytes.
            CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);
            //Return decrypted string
            string DecryptedString = new StreamReader(cryptostreamDecr).ReadToEnd();
            return DecryptedString;
        }

    }
}
