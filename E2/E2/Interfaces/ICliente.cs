using System;

namespace E2.Interfaces;

public interface ICliente
{
    int Id { get; set; }
    string Nome { get; set; }
    string Sobrenome { get; set; }
    string CPF { get; set; }
    DateTime DataNascimento { get; set; }
    string Telefone { get; set; }
    decimal Email { get; set; }
    int Endereco { get; set; }
}