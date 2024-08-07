using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        AsymmetricEncryption encryption = new AsymmetricEncryption();

        // Gerar e salvar chaves RSA
        encryption.GenerateAndSaveKeys("publicKey.xml", "privateKey.xml");

        // Ler as chaves dos arquivos
        string publicKey = File.ReadAllText("publicKey.xml");
        string privateKey = File.ReadAllText("privateKey.xml");

        // Exemplo de criptografia e descriptografia de texto
        string originalText = "Abacate";
        string encryptedText = encryption.EncryptText(originalText, publicKey);
        string decryptedText = encryption.DecryptText(encryptedText, privateKey);

        Console.WriteLine("Original: " + originalText);
        Console.WriteLine("Encrypted: " + encryptedText);
        Console.WriteLine("Decrypted: " + decryptedText);

        // Exemplo de criptografia e descriptografia de arquivos
        string inputFilePath = "C:/POO ENGEL/POO/Criptografia/Criptografia/Arquivos/texto.txt";
        string encryptedFilePath = "C:/POO ENGEL/POO/Criptografia/Criptografia/Arquivos/texto.txt";  // Substitua pelo caminho do arquivo criptografado
        string decryptedFilePath = "C:/POO ENGEL/POO/Criptografia/Criptografia/Arquivos/texto.txt";  // Substitua pelo caminho do arquivo descriptografado

        encryption.EncryptFile(inputFilePath, encryptedFilePath, publicKey);
        encryption.DecryptFile(encryptedFilePath, decryptedFilePath, privateKey);
    }
}
