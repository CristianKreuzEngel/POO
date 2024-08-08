using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class SymmetricEncryption
{
    private readonly string key;
    private readonly string iv;

    public SymmetricEncryption()
    {
        // Gerar chave e IV aleatórios para criptografia simétrica
        using (Aes aes = Aes.Create())
        {
            key = Convert.ToBase64String(aes.Key);
            iv = Convert.ToBase64String(aes.IV);
        }
    }

    public void EncryptFile(string inputFilePath, string outputFilePath)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            aes.IV = Convert.FromBase64String(iv);

            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream fsOutput = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
            using (CryptoStream cs = new CryptoStream(fsOutput, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                fsInput.CopyTo(cs);
            }
        }
    }

    public void DecryptFile(string inputFilePath, string outputFilePath)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            aes.IV = Convert.FromBase64String(iv);

            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream fsOutput = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
            using (CryptoStream cs = new CryptoStream(fsInput, aes.CreateDecryptor(), CryptoStreamMode.Read))
            {
                cs.CopyTo(fsOutput);
            }
        }
    }

    public string EncryptText(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            aes.IV = Convert.FromBase64String(iv);

            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            using (StreamWriter sw = new StreamWriter(cs))
            {
                sw.Write(plainText);
            }

            return Convert.ToBase64String(ms.ToArray());
        }
    }

    public string DecryptText(string cipherText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            aes.IV = Convert.FromBase64String(iv);

            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
            using (StreamReader sr = new StreamReader(cs))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
