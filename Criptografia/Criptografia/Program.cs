using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        AsymmetricEncryption asymmetricEncryption = new AsymmetricEncryption();
        SymmetricEncryption symmetricEncryption = new SymmetricEncryption();

        // Gerar e salvar chaves RSA
        asymmetricEncryption.GenerateAndSaveKeys("publicKey.xml", "privateKey.xml");

        // Ler as chaves dos arquivos
        string publicKey = File.ReadAllText("publicKey.xml");
        string privateKey = File.ReadAllText("privateKey.xml");

        string lastEncryptedText = null;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Escolha o tipo de criptografia:");
            Console.WriteLine("1. Criptografia Assimétrica");
            Console.WriteLine("2. Criptografia Simétrica");
            Console.WriteLine("3. Sair");
            Console.Write("Opção: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAsymmetricMenu(asymmetricEncryption, publicKey, privateKey, ref lastEncryptedText);
                    break;
                case "2":
                    ShowSymmetricMenu(symmetricEncryption, ref lastEncryptedText);
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private static void ShowAsymmetricMenu(AsymmetricEncryption encryption, string publicKey, string privateKey, ref string lastEncryptedText)
    {
        bool back = false;

        while (!back)
        {
            Console.WriteLine("Escolha a operação:");
            Console.WriteLine("1. Criptografar um arquivo");
            Console.WriteLine("2. Descriptografar um arquivo");
            Console.WriteLine("3. Criptografar um texto");
            Console.WriteLine("4. Descriptografar o texto criptografado");
            Console.WriteLine("5. Voltar");
            Console.Write("Opção: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string inputFilePath = "C:/POO ENGEL/POO/Criptografia/Criptografia/Arquivos/texto.txt";
                    string encryptedFilePath = "C:/POO ENGEL/POO/Criptografia/Criptografia/Arquivos/texto_criptografado.txt";
                    encryption.EncryptFile(inputFilePath, encryptedFilePath, publicKey);
                    Console.WriteLine("Arquivo criptografado com sucesso.");
                    break;
                case "2":
                    string encryptedInputFilePath = "C:/POO ENGEL/POO/Criptografia/Criptografia/Arquivos/texto_criptografado.txt";
                    string decryptedFilePath = "C:/POO ENGEL/POO/Criptografia/Criptografia/Arquivos/texto_descriptografado.txt";
                    encryption.DecryptFile(encryptedInputFilePath, decryptedFilePath, privateKey);
                    Console.WriteLine("Arquivo descriptografado com sucesso.");
                    break;
                case "3":
                    string originalText = null;
                    do
                    {
                        Console.Write("Digite o texto a ser criptografado (não pode ser vazio): ");
                        originalText = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(originalText));

                    lastEncryptedText = encryption.EncryptText(originalText, publicKey);
                    Console.WriteLine("Texto criptografado: " + lastEncryptedText);
                    break;
                case "4":
                    if (lastEncryptedText == null)
                    {
                        Console.WriteLine("Nenhum texto criptografado encontrado.");
                    }
                    else
                    {
                        string decryptedText = encryption.DecryptText(lastEncryptedText, privateKey);
                        Console.WriteLine("Texto descriptografado: " + decryptedText);
                    }
                    break;
                case "5":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private static void ShowSymmetricMenu(SymmetricEncryption encryption, ref string lastEncryptedText)
    {
        bool back = false;

        while (!back)
        {
            Console.WriteLine("Escolha a operação:");
            Console.WriteLine("1. Criptografar um arquivo");
            Console.WriteLine("2. Descriptografar um arquivo");
            Console.WriteLine("3. Criptografar um texto");
            Console.WriteLine("4. Descriptografar o texto criptografado");
            Console.WriteLine("5. Voltar");
            Console.Write("Opção: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string inputFilePath = "C:/POO ENGEL/POO/Criptografia/Criptografia/Arquivos/texto.txt";
                    string encryptedFilePath = "C:/POO ENGEL/POO/Criptografia/Criptografia/Arquivos/texto_criptografado_simetrico.txt";
                    encryption.EncryptFile(inputFilePath, encryptedFilePath);
                    Console.WriteLine("Arquivo criptografado com sucesso.");
                    break;
                case "2":
                    string encryptedInputFilePath = "C:/POO ENGEL/POO/Criptografia/Criptografia/Arquivos/texto_criptografado_simetrico.txt";
                    string decryptedFilePath = "C:/POO ENGEL/POO/Criptografia/Criptografia/Arquivos/texto_descriptografado_simetrico.txt";
                    encryption.DecryptFile(encryptedInputFilePath, decryptedFilePath);
                    Console.WriteLine("Arquivo descriptografado com sucesso.");
                    break;
                case "3":
                    string originalText = null;
                    do
                    {
                        Console.Write("Digite o texto a ser criptografado (não pode ser vazio): ");
                        originalText = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(originalText));

                    lastEncryptedText = encryption.EncryptText(originalText);
                    Console.WriteLine("Texto criptografado: " + lastEncryptedText);
                    break;
                case "4":
                    if (lastEncryptedText == null)
                    {
                        Console.WriteLine("Nenhum texto criptografado encontrado.");
                    }
                    else
                    {
                        string decryptedText = encryption.DecryptText(lastEncryptedText);
                        Console.WriteLine("Texto descriptografado: " + decryptedText);
                    }
                    break;
                case "5":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
