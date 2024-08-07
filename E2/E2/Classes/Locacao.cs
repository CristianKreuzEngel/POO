using System;
using System.Collections.Generic;
using System.Linq;
using E2.Interfaces;

namespace E2.Classes;

public class Locacao : ILocacao
{
    private int _id;
    private string _cliente;
    private string _filme;
    private DateTime _datalocacao;
    private DateTime _datadevolucao;
    private decimal _valortotal;
    private bool _devolvido;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Cliente
    {
        get { return _cliente; }
        set { _cliente = value; }
    }

    public string Filme
    {
        get { return _filme; }
        set { _filme = value; }
    }

    public DateTime DataLocacao
    {
        get { return _datalocacao; }
        set { _datalocacao = value; }
    }

    public DateTime DataDevolucao
    {
        get { return _datadevolucao; }
        set { _datadevolucao = value; }
    }

    public decimal ValorTotal
    {
        get { return _valortotal; }
        set { _valortotal = value; }
    }

    public bool Devolvido
    {
        get { return _devolvido; }
        set { _devolvido = value; }
    }
    public enum Header
    {
        Id = 0,
        Cliente = 1,
        Filme = 2,
        DataLocacao = 3,
        DataDevolucao = 4,
        ValorTotal = 5,
        Devolvido = 6,
    }
    public static List<Locacao> ConverterLista(string arquivo)
    {
        List<Locacao> locacoes = new();

        var linhas = arquivo.Split('\n').ToList();

        linhas.Remove(linhas.First());

        foreach (var linha in linhas)
        {
            Locacao locacao = new()
            {
                Id = Convert.ToInt32(linha.Split(';')[(int)Header.Id]),
                Cliente = linha.Split(";")[(int)Header.Cliente],
                Filme = linha.Split(";")[(int)Header.Filme],
                DataLocacao = Convert.ToDateTime(linha.Split(";")[(int)Header.DataLocacao]),
                DataDevolucao = Convert.ToDateTime(linha.Split(';')[(int)Header.DataDevolucao]),
                ValorTotal = Convert.ToDecimal(linha.Split(';')[(int)Header.ValorTotal]),
                Devolvido = Convert.ToBoolean(linha.Split(';')[(int)Header.Devolvido]),
            };
            locacoes.Add(locacao);
        }

        return locacoes;
    }
}