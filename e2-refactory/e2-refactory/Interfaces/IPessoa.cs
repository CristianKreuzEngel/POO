using System;

namespace e2_refactory.Interfaces;

public interface IPessoa
{
    string Nome { get; set; }
    string Cpf { get; set; }
    string Telefone { get; set; }
    DateTime DataNascimento { get; set; }
    string Endereco { get; set; }
}