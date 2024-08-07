using System;

namespace E2.Interfaces;

public interface ILocacao
{
    int Id { get; set; }
    string Cliente { get; set; }
    string Filme { get; set; }
    DateTime DataLocacao { get; set; }
    DateTime DataDevolucao { get; set; }
    decimal ValorTotal { get; set; }
    bool Devolvido { get; set; }
}