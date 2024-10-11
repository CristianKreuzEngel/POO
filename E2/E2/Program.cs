using System;
using System.Collections.Generic;
using E2.Classes;
using E2.Interfaces;

int opcao;
var relatorio = new Relatorio();
var inventario = new Inventario();

do
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1) Consultar Locações");
    Console.WriteLine("2) Consultar Filmes");
    Console.WriteLine("3) Consultar Clientes");
    Console.WriteLine("4) Consultar Funcionário");
    Console.WriteLine("5) Adicionar Filme");
    Console.WriteLine("6) Remover Filme");
    Console.WriteLine("0) Sair do programa");
    Console.Write("Escolha uma opção: ");
    
    if (!int.TryParse(Console.ReadLine(), out opcao))
    {
        Console.WriteLine("Opção inválida. Por favor, insira um número.");
        continue;
    }
    try
    {
        switch (opcao)
        {
            case 1:
                relatorio.GerarRelatorioLocacoes();
                break;
            case 2:
                relatorio.GerarRelatorioFilmes();
                break;
            case 3:
                relatorio.GerarRelatorioClientes();
                break;
            case 4:
                relatorio.GerarRelatorioFuncionarios();
                break;
            case 5:
                inventario.AdicionarFilme();
                break;
            case 6:
                RemoverFilme(inventario);
                break;
            case 0:
                Console.WriteLine("Saindo");
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    catch (FormatException ex)
    {
        Console.WriteLine($"Erro de formato: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro inesperado: {ex.Message}");
    }

} while (opcao != 0);

void RemoverFilme(Inventario inventario)
{
    try
    {
        

        inventario.RemoverFilme(id);

        Console.WriteLine("Filme removido com sucesso.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao remover filme: {ex.Message}");
    }
}

