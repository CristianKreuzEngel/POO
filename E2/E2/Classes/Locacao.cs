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
            if (string.IsNullOrWhiteSpace(linha))
                continue;

            var colunas = linha.Split(',');

            Locacao locacao = new()
            {
                Id = int.Parse(colunas[(int)Header.Id].Trim()),
                Cliente = colunas[(int)Header.Cliente].Trim(),
                Filme = colunas[(int)Header.Filme].Trim(),
                DataLocacao = DateTime.Parse(colunas[(int)Header.DataLocacao].Trim()),
                DataDevolucao = DateTime.Parse(colunas[(int)Header.DataDevolucao].Trim()),
                ValorTotal = decimal.Parse(colunas[(int)Header.ValorTotal].Trim(), System.Globalization.CultureInfo.InvariantCulture),
                Devolvido = bool.Parse(colunas[(int)Header.Devolvido].Trim())
            };
            locacoes.Add(locacao);
        }

        return locacoes;
    }
}