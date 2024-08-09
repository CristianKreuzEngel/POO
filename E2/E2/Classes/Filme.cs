using System;
using System.Collections.Generic;
using System.Linq;
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

    public enum Header
    {
        Id = 0,
        Titulo = 1,
        Genero = 2,
        DataLancamento = 3,
        Diretor = 4,
        Preco = 5,
        Estoque = 6
    }

    public static List<Filme> ConverterLista(string arquivo)
    {
        List<Filme> filmes = new();
    
        var linhas = arquivo.Split('\n').ToList();
    
        linhas.Remove(linhas.First());
    
        foreach (var linha in linhas)
        {
            if (string.IsNullOrWhiteSpace(linha))
                continue;
    
            var colunas = linha.Split(',');
    
            Filme filme = new()
            {
                Id = int.Parse(colunas[(int)Header.Id].Trim()),
                Titulo = colunas[(int)Header.Titulo].Trim(),
                Genero = colunas[(int)Header.Genero].Trim(),
                DataLancamento = DateTime.Parse(colunas[(int)Header.DataLancamento].Trim()),
                Diretor = colunas[(int)Header.Diretor].Trim(),
                Preco = decimal.Parse(colunas[(int)Header.Preco].Trim(), System.Globalization.CultureInfo.InvariantCulture),
                Estoque = int.Parse(colunas[(int)Header.Estoque].Trim())
            };
            filmes.Add(filme);
        }
    
        return filmes;
    }
}
