using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using E2.Interfaces;

namespace E2.Classes;

public class Cliente : IPessoa
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
    public int Id { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
     public string Endereco { get; set; }
     
    public enum Header
    {
        Id = 0,
        Nome = 1,
        Sobrenome = 2,
        CPF = 3,
        DataDeNascimento = 4,
        Telefone = 5,
        Email = 6,
        Endereco = 7
    }
    public static List<Cliente> ConverterLista(string arquivo)
    {
        List<Cliente> clientes = new();

        var linhas = arquivo.Split('\n').ToList();

        linhas.Remove(linhas.First());

        foreach (var linha in linhas)
        {
            if (string.IsNullOrWhiteSpace(linha))
                continue;

            var colunas = linha.Split(',');

            Cliente cliente = new()
            {
                Id = int.Parse(colunas[(int)Header.Id].Trim()),
                Nome = colunas[(int)Header.Nome].Trim(),
                Cpf = colunas[(int)Header.CPF].Trim(),
                DataNascimento = DateTime.Parse(colunas[(int)Header.DataDeNascimento].Trim()),
                Telefone = colunas[(int)Header.Telefone].Trim(),
                Email = colunas[(int)Header.Email].Trim(),
                Endereco = colunas[(int)Header.Endereco].Trim()
            };
            clientes.Add(cliente);
        }

        return clientes;
    }
}