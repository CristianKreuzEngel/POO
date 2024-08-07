using E2.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace E2.Classes;


public class Relatorio: IRelatorio
{
    private string datasetLocacoes = File.ReadAllText("./BancoDeDados/locacoes.csv");
    private static string datasetClientes = File.ReadAllText("./BancoDeDados/clientes.csv");
    private List<Cliente> _listCliente = Cliente.ConverterLista(datasetClientes);
    private string datasetFilmes = File.ReadAllText("./BancoDeDados/filmes.csv");
    private string datasetFuncionarios = File.ReadAllText("./BancoDeDados/funcionarios.csv");
    public void GerarRelatorioLocacoes()
    {
        
    }

    public void GerarRelatorioClientes()
    {
        
    }

    public void GerarRelatorioFilmes()
    {
        
    }

    public void GerarRelatorioFuncionarios()
    {
        
    }
}