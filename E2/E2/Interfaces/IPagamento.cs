using System;

namespace E2.Interfaces;

public interface IPagamento
{
    int Id { get; set; }
    ICliente Cliente { get; set; }
    decimal Valor { get; set; }
    DateTime DataPagamento { get; set; }
    string MetodoPagamento { get; set; }
    bool Confirmado { get; set; }
}