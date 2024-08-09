using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using E2.Interfaces;

namespace E2.Classes;

public class Funcionario : IFuncionario
{
    private int _id;
    private string _nome;
    private string _sobrenome;
    private string _cpf;
    private DateTime _datanascimento;
    private string _telefone;
    private string _email;
    private string _cargo;
    private decimal _salario;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public string Sobrenome
    {
        get { return _sobrenome; }
        set { _sobrenome = value; }
    }

    public string CPF
    {
        get { return _cpf; }
        set { _cpf = value; }
    }

    public DateTime DataNascimento
    {
        get { return _datanascimento; }
        set { _datanascimento = value; }
    }

    public string Telefone
    {
        get { return _telefone; }
        set { _telefone = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public string Cargo
    {
        get { return _cargo; }
        set { _cargo = value; }
    }

    public decimal Salario
    {
        get { return _salario; }
        set { _salario = value; }
    }

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
                Sobrenome = colunas[(int)Header.Sobrenome].Trim(),
                CPF = colunas[(int)Header.CPF].Trim(),
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
