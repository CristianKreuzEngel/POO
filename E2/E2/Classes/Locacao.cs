using System;
using E2.Interfaces;

namespace E2.Classes;

public class Locacao : ILocacao
{
    private int _id;
    private ICliente _cliente;
    private IFilme _filme;
    private DateTime _datalocacao;
    private DateTime _datadevolucao;
    private decimal _valortotal;
    private bool _devolvido;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public ICliente Cliente
    {
        get { return _cliente; }
        set { _cliente = value; }
    }

    public IFilme Filme
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
}