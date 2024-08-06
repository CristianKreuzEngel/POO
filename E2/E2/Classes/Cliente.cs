using System;
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
        get { return _id;}
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
}