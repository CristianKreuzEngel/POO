using System;
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

    public void AdicionarFuncionario()
    {
        throw new NotImplementedException();
    }

    public void RemoverFuncionario()
    {
        throw new NotImplementedException();
    }

    public void EditarFuncionario()
    {
        throw new NotImplementedException();
    }
}