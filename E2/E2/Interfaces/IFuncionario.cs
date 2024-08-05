using System;

namespace E2.Interfaces;

public interface IFuncionario
{
    int Id { get; set; }
    string Nome { get; set; }
    string Sobrenome { get; set; }
    string CPF { get; set; }
    DateTime DataNascimento { get; set; }
    string Telefone { get; set; }
    string Email { get; set; }
    string Cargo { get; set; }
    decimal Salario { get; set; }
    
    void AdicionarFuncionario();
    void RemoverFuncionario();
    void EditarFuncionario();
}