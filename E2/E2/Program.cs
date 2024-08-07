using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using E2.Classes;
int opcao;
do
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1) Produtos mais vendidos");
    Console.WriteLine("2) Produtos com mais estoque");
    Console.WriteLine("3) Categoria mais vendida");
    Console.WriteLine("4) Produtos menos vendidos");
    Console.WriteLine("5) Estoque de segurança");
    Console.WriteLine("6) Excesso de estoque");
    Console.WriteLine("7) Média de preço por categoria");
    Console.WriteLine("0) sair do programa");
    Console.Write("Escolha uma opção: ");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
           
            break;
        case 2:
            
            break;
        case 3:
            
            break;
        case 4:
            
            break;
        case 5:
            
            break;
        case 6:
            
            break;
        case 7:
            
            break;
        case 0:
            Console.WriteLine("Saindo");
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

} while (opcao != 0);