using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using E2.Interfaces;

namespace E2.Classes;

public class Cliente : ICliente
{
    private int _id;
    private string _nome;
    private string _sobrenome;
    private string _cpf;
    private DateTime _datanascimento;
    private string _telefone;
    private string _email;
    private string _endereco;


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

    public string Endereco
    {
        get { return _endereco; }
        set { _endereco = value; }
    }

    public void AdicionarCliente()
    {
        throw new NotImplementedException();
    }

    public void RemoverCliente()
    {
        throw new NotImplementedException();
    }

    public void EditarCliente()
    {
        throw new NotImplementedException();
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
        Endereco = 7
    }
    public static List<Cliente> ConverterLista(string arquivo)
    {
        List<Cliente> clientes = new();

        var linhas = arquivo.Split('\n').ToList();

        linhas.Remove(linhas.First()); // Remove a linha de cabeçalho

        foreach (var linha in linhas)
        {
            if (string.IsNullOrWhiteSpace(linha))
                continue;

            var colunas = linha.Split(',');

            Cliente cliente = new()
            {
                Id = int.Parse(colunas[(int)Header.Id].Trim()),
                Nome = colunas[(int)Header.Nome].Trim(),
                Sobrenome = colunas[(int)Header.Sobrenome].Trim(),
                CPF = colunas[(int)Header.CPF].Trim(),
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