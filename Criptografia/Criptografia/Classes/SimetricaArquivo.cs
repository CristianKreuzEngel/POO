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

    public void EncryptFile(string filePath)
    {
        byte[] data = File.ReadAllBytes(filePath);
        byte[] encryptedData = EncryptData(data);

        File.WriteAllBytes(filePath, encryptedData);
    }

    public void DecryptFile(string filePath)
    {
        byte[] encryptedData = File.ReadAllBytes(filePath);
        byte[] decryptedData = DecryptData(encryptedData);

        File.WriteAllBytes(filePath, decryptedData);
    }

    public string EncryptText(string plainText)
    {
        byte[] data = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedData = EncryptData(data);

        return Convert.ToBase64String(encryptedData);
    }

    public string DecryptText(string cipherText)
    {
        byte[] encryptedData = Convert.FromBase64String(cipherText);
        byte[] decryptedData = DecryptData(encryptedData);

        return Encoding.UTF8.GetString(decryptedData);
    }

    private byte[] EncryptData(byte[] data)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            aes.IV = Convert.FromBase64String(iv);

            MemoryStream ms;
            using (ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(data, 0, data.Length);
                cs.Close();
            }

            return ms.ToArray();
        }
    }

    private byte[] DecryptData(byte[] data)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            aes.IV = Convert.FromBase64String(iv);

            using (MemoryStream ms = new MemoryStream(data))
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
            using (MemoryStream output = new MemoryStream())
            {
                cs.CopyTo(output);
                return output.ToArray();
            }
        }
    }
}
