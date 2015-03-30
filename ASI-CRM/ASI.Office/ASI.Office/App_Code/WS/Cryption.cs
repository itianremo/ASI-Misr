using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;

public abstract class Cryption
{
    private static byte[] PubKeyBytes;
    private static byte[] PubVectorBytes;
    private static byte[] KeyBytes = ASCIIEncoding.ASCII.GetBytes("Bo'O,p;ortf,j8y" + Math.PI.ToString().Substring(0, 10) + Math.E.ToString().Substring(0, 7));
    private static byte[] VectorBytes = ASCIIEncoding.ASCII.GetBytes("gfgvbg!acxv.h" + Math.E.ToString().Substring(0, 3));

    private static byte[] GetKey()
    {
        if (PubKeyBytes != null)
        {
            if (PubKeyBytes.Length == 32)
                return PubKeyBytes;
            else
                return KeyBytes;
        }
        else
            return KeyBytes;
    }

    private static byte[] GetVector()
    {
        if (PubVectorBytes != null)
        {
            if (PubVectorBytes.Length == 32)
                return PubVectorBytes;
            else
                return VectorBytes;
        }
        else
            return VectorBytes;
    }

    public static void SetKey(string KeyValue)
    {
        PubKeyBytes = ASCIIEncoding.ASCII.GetBytes(KeyValue);
        if (PubKeyBytes == null)
            PubKeyBytes = KeyBytes;
        else
        {
            if (PubKeyBytes.Length != 32)
                PubKeyBytes = KeyBytes;
        }
    }

    public static void SetVector(string VectorValue)
    {
        PubVectorBytes = ASCIIEncoding.ASCII.GetBytes(VectorValue);
        if (PubVectorBytes == null)
            PubVectorBytes = VectorBytes;
        else
        {
            if (PubVectorBytes.Length != 32)
                PubVectorBytes = VectorBytes;
        }
    }

    /// <summary>
    /// Encrypt a string.
    /// </summary>
    /// <param name="originalString">The original string.</param>
    /// <returns>The encrypted string.</returns>
    /// <exception cref="ArgumentNullException">This exception will be 
    /// thrown when the original string is null or empty.</exception>
    public static string Encrypt(string originalString)
    {
        if (String.IsNullOrEmpty(originalString))
        {
            return "";
        }
        Rijndael cryptoProvider = Rijndael.Create();
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream,
            cryptoProvider.CreateEncryptor(GetKey(), GetVector()), CryptoStreamMode.Write);
        StreamWriter writer = new StreamWriter(cryptoStream);
        writer.Write(originalString);
        writer.Flush();
        cryptoStream.FlushFinalBlock();
        writer.Flush();
        
        MemoryStream output = new MemoryStream();
        GZipStream gzip = new GZipStream(output, CompressionMode.Compress, true);
        gzip.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        gzip.Close();

        return Convert.ToBase64String(output.GetBuffer(), 0, (int)output.Length);
    }

    /// <summary>
    /// Decrypt a crypted string.
    /// </summary>
    /// <param name="cryptedString">The crypted string.</param>
    /// <returns>The decrypted string.</returns>
    /// <exception cref="ArgumentNullException">This exception will be thrown 
    /// when the crypted string is null or empty.</exception>
    public static string Decrypt(string cryptedString)
    {
        if (String.IsNullOrEmpty(cryptedString))
        {
            return "";
        }

        byte[] data = Convert.FromBase64String(cryptedString);
        MemoryStream input = new MemoryStream();
        input.Write(data, 0, data.Length);
        input.Position = 0;
        GZipStream gzip = new GZipStream(input, CompressionMode.Decompress, true);
        MemoryStream output = new MemoryStream();
        byte[] buff = new byte[64];
        int read = -1;
        read = gzip.Read(buff, 0, buff.Length);
        while (read > 0)
        {
            output.Write(buff, 0, read);
            read = gzip.Read(buff, 0, buff.Length);
        }
        gzip.Close();

        Rijndael cryptoProvider = Rijndael.Create();
        MemoryStream memoryStream = new MemoryStream
                (output.ToArray());
        CryptoStream cryptoStream = new CryptoStream(memoryStream,
            cryptoProvider.CreateDecryptor(GetKey(), GetVector()), CryptoStreamMode.Read);
        StreamReader reader = new StreamReader(cryptoStream);
        return reader.ReadToEnd();
    }

    /// <summary>
    /// Encrypt a string in one-way algorithm (Md5).
    /// </summary>
    /// <param name="passwordString">The password string.</param>
    /// <returns>The encrypted password.</returns>
    /// <exception cref="ArgumentNullException">This exception will be 
    /// thrown when the password string is null or empty.</exception>
    public static string Md5AddSecret(string passwordString)
    {
        if (String.IsNullOrEmpty(passwordString))
        {
            throw new ArgumentNullException
               ("The string which needs to be encrypted can not be null.");
        }
        byte[] pass = Encoding.UTF8.GetBytes(passwordString);
        MD5 md5 = new MD5CryptoServiceProvider();
        return Convert.ToBase64String(md5.ComputeHash(pass));
    }

    /// <summary>
    /// Encrypt a string in one-way algorithm (SHA2).
    /// </summary>
    /// <param name="passwordString">The password string.</param>
    /// <returns>The encrypted password.</returns>
    /// <exception cref="ArgumentNullException">This exception will be 
    /// thrown when the password string is null or empty.</exception>
    public static string SHA2AddSecret(string passwordString)
    {
        if (String.IsNullOrEmpty(passwordString))
        {
            throw new ArgumentNullException
               ("The string which needs to be encrypted can not be null.");
        }
        byte[] pass = Encoding.UTF8.GetBytes(passwordString);
        return Convert.ToBase64String(SHA384.Create().ComputeHash(pass));
    }

    /// <summary>
    /// Encrypt a string in one-way algorithm.
    /// </summary>
    /// <param name="passwordString">The password string.</param>
    /// <returns>The encrypted password.</returns>
    /// <exception cref="ArgumentNullException">This exception will be 
    /// thrown when the password string is null or empty.</exception>
    public static string EncryptPass(string passwordString)
    {
        if (String.IsNullOrEmpty(passwordString))
        {
            throw new ArgumentNullException
               ("The string which needs to be encrypted can not be null.");
        }
        return Cryption.SHA2AddSecret(passwordString);
    }
}