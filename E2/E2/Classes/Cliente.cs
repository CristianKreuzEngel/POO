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

        linhas.Remove(linhas.First());

        foreach (var linha in linhas)
        {
            Cliente cliente = new()
            {
                Id = Convert.ToInt32(
                    linha.Split(';')[(int)Header.Id]),
                Nome = linha.Split(";")[(int)Header.Nome],
                Sobrenome = linha.Split(";")[(int)Header.Sobrenome],
                CPF = linha.Split(";")[(int)Header.CPF],
                DataNascimento = Convert.ToDateTime(linha.Split(';')[(int)Header.DataDeNascimento]),
                Telefone = linha.Split(';')[(int)Header.Telefone],
                Email = linha.Split(';')[(int)Header.Email],
                Endereco = linha.Split(';')[(int)Header.Endereco],
            };
            clientes.Add(cliente);
        }

        return clientes;
    }
}