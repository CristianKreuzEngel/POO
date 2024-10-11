using System;
using E2.Interfaces;

namespace E2.Classes;

public class Pagamento : IPagamento
{
    private int _id;
    private IPessoa _cliente;
    private decimal _valor;
    private DateTime _datapagamento;
    private string _metodopagamento;
    private bool _confirmado;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public IPessoa Cliente
    {
        get { return _cliente; }
        set { _cliente = value; }
    }

    public decimal Valor
    {
        get { return _valor; }
        set { _valor = value; }
    }

    public DateTime DataPagamento
    {
        get { return _datapagamento; }
        set { _datapagamento = value; }
    }

    public string MetodoPagamento
    {
        get { return _metodopagamento; }
        set { _metodopagamento = value; }
    }

    public bool Confirmado
    {
        get { return _confirmado; }
        set { _confirmado = value; }
    }
}