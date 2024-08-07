﻿using System;

namespace E2.Interfaces;

public interface IFilme
{
    int Id { get; set; }
    string Titulo { get; set; }
    string Genero { get; set; }
    DateTime DataLancamento { get; set; }
    string Diretor { get; set; }
    decimal Preco { get; set; }
    int Estoque { get; set; }
}