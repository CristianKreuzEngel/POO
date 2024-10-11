using System;
using e2_refactory.Interfaces;

namespace e2_refactory.Classes;

public class Cliente : IPessoa
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Endereco { get; set; }
}