using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using E2.Interfaces;

namespace E2.Classes;

public class Funcionario : IFuncionario
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Cpf { get; set; }

    public DateTime DataNascimento { get; set; }

    public string Telefone { get; set; }
    
    public string Endereco { get; set; }
    public string Email { get; set; }

    public string Cargo { get; set; }
    public decimal Salario { get; set; }
    public enum Header
    {
        Id = 0,
        Nome = 1,
        Sobrenome = 2,
        CPF = 3,
        DataDeNascimento = 4,
        Telefone = 5,
        Email = 6,
        Cargo = 7,
        Salario = 8
    }

    public static List<Funcionario> ConverterLista(string arquivo)
    {
        List<Funcionario> funcionarios = new();

        var linhas = arquivo.Split('\n').ToList();

        linhas.Remove(linhas.First());

        foreach (var linha in linhas)
        {
            if (string.IsNullOrWhiteSpace(linha))
                continue;

            var colunas = linha.Split(',');

            Funcionario funcionario = new()
            {
                Id = int.Parse(colunas[(int)Header.Id].Trim()),
                Nome = colunas[(int)Header.Nome].Trim(),
                Cpf = colunas[(int)Header.CPF].Trim(),
                DataNascimento = DateTime.Parse(colunas[(int)Header.DataDeNascimento].Trim()),
                Telefone = colunas[(int)Header.Telefone].Trim(),
                Email = colunas[(int)Header.Email].Trim(),
                Cargo = colunas[(int)Header.Cargo].Trim(),
                Salario = decimal.Parse(colunas[(int)Header.Salario].Trim(), System.Globalization.CultureInfo.InvariantCulture)
            };
            funcionarios.Add(funcionario);
        }

        return funcionarios;
    }
}
