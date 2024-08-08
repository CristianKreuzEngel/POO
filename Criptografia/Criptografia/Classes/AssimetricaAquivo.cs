using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AsymmetricEncryption
{
    private RSA rsa;

    public AsymmetricEncryption()
    {
        rsa = RSA.Create();
    }
    
    public void GenerateAndSaveKeys(string publicKeyPath, string privateKeyPath)
    {
        string publicKey = rsa.ToXmlString(false);  
        string privateKey = rsa.ToXmlString(true);  

        File.WriteAllText(publicKeyPath, publicKey);
        File.WriteAllText(privateKeyPath, privateKey);

        Console.WriteLine("Chaves geradas e salvas com sucesso.");
    }

    public void EncryptFile(string inputFilePath, string outputFilePath, string publicKey)
    {
        var data = File.ReadAllBytes(inputFilePath);
        var encryptedData = EncryptData(data, publicKey);
        File.WriteAllBytes(outputFilePath, encryptedData);
    }

    public void DecryptFile(string inputFilePath, string outputFilePath, string privateKey)
    {
        var encryptedData = File.ReadAllBytes(inputFilePath);
        var decryptedData = DecryptData(encryptedData, privateKey);
        File.WriteAllBytes(outputFilePath, decryptedData);
    }

    public string EncryptText(string text, string publicKey)
    {
        var data = Encoding.UTF8.GetBytes(text);
        var encryptedData = EncryptData(data, publicKey);
        return Convert.ToBase64String(encryptedData);
    }

    public string DecryptText(string encryptedText, string privateKey)
    {
        var encryptedData = Convert.FromBase64String(encryptedText);
        var decryptedData = DecryptData(encryptedData, privateKey);
        return Encoding.UTF8.GetString(decryptedData);
    }

    private byte[] EncryptData(byte[] data, string publicKey)
    {
        rsa.FromXmlString(publicKey);
        return rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
    }

    private byte[] DecryptData(byte[] data, string privateKey)
    {
        rsa.FromXmlString(privateKey);
        return rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
    }
}
