using System;

namespace E2.Interfaces;

public interface IFuncionario : IPessoa
{
    int Id { get; set; }
    string Nome { get; set; }
    string Cpf { get; set; }
    DateTime DataNascimento { get; set; }
    string Endereco { get; set; }
    string Telefone { get; set; }
    string Email { get; set; }
    string Cargo { get; set; }
    decimal Salario { get; set; }
}