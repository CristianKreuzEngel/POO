using System;
using E2.Interfaces;

namespace E2.Classes;

public class Filme : IFilme
{
    private int _id;
    private string _titulo;
    private string _genero;
    private DateTime _dataLancamento;
    private string _diretor;
    private decimal _preco;
    private int _estoque;
    
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Titulo
    {
        get { return _titulo;}
        set { _titulo = value; }
    }
    public string Genero
    {
        get { return _genero;}
        set { _genero = value; }
    }

    public DateTime DataLancamento
    {
        get
        {
            return _dataLancamento;
        }
        set
        {
            _dataLancamento = value;
        }
    }

    public string Diretor
    {
        get
        {
            return _diretor;
        }
        set
        {
            _diretor = value;
        }
    }

    public decimal Preco 
    { 
        get { return _preco; } 
        set { _preco = value; } 
    }

    public int Estoque
    {
        get
        {
            return _estoque;
        }
        set
        {
            _estoque = value;
        }
    }
}