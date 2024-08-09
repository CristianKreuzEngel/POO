using E2.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace E2.Classes
{
    public class Relatorio : IRelatorio
    {
        private readonly string caminhoLocacoes = @"C:\projects\POO\E2\E2\BancoDeDados\locacoes.csv";
        private readonly string caminhoClientes = @"C:\projects\POO\E2\E2\BancoDeDados\clientes.csv";
        private readonly string caminhoFilmes = @"C:\projects\POO\E2\E2\BancoDeDados\filmes.csv";
        private readonly string caminhoFuncionarios = @"C:\projects\POO\E2\E2\BancoDeDados\funcionarios.csv";

        public void GerarRelatorioLocacoes()
        {
            string datasetLocacoes = File.ReadAllText(caminhoLocacoes);
            List<Locacao> listaLocacoes = Locacao.ConverterLista(datasetLocacoes);

            Console.WriteLine("Lista de Locações:");
            foreach (var locacao in listaLocacoes)
            {
                Console.WriteLine($"ID: {locacao.Id}");
                Console.WriteLine($"Cliente: {locacao.Cliente}");
                Console.WriteLine($"Filme: {locacao.Filme}");
                Console.WriteLine($"Data de Locação: {locacao.DataLocacao.ToShortDateString()}");
                Console.WriteLine($"Data de Devolução: {locacao.DataDevolucao.ToShortDateString()}");
                Console.WriteLine($"Valor Total: R${locacao.ValorTotal}");
                Console.WriteLine($"Devolvido: {(locacao.Devolvido ? "Sim" : "Não")}");
                Console.WriteLine(new string('-', 20));
            }
        }

        public void GerarRelatorioClientes()
        {
            string datasetClientes = File.ReadAllText(caminhoClientes);
            List<Cliente> listaClientes = Cliente.ConverterLista(datasetClientes);

            Console.WriteLine("Lista de Clientes:");
            foreach (var cliente in listaClientes)
            {
                Console.WriteLine($"ID: {cliente.Id}");
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"Sobrenome: {cliente.Sobrenome}");
                Console.WriteLine($"CPF: {cliente.CPF}");
                Console.WriteLine($"Data de Nascimento: {cliente.DataNascimento.ToShortDateString()}");
                Console.WriteLine($"Telefone: {cliente.Telefone}");
                Console.WriteLine($"Email: {cliente.Email}");
                Console.WriteLine($"Endereço: {cliente.Endereco}");
                Console.WriteLine(new string('-', 20));
            }
        }

        public void GerarRelatorioFilmes()
        {
            var inventario = new Inventario();
            var filmes = inventario.ListarTodosFilmes();

            Console.WriteLine("Lista de Filmes:");
            foreach (var filme in filmes)
            {
                Console.WriteLine($"ID: {filme.Id}");
                Console.WriteLine($"Título: {filme.Titulo}");
                Console.WriteLine($"Gênero: {filme.Genero}");
                Console.WriteLine($"Data de Lançamento: {filme.DataLancamento.ToShortDateString()}");
                Console.WriteLine($"Diretor: {filme.Diretor}");
                Console.WriteLine($"Preço: R${filme.Preco}");
                Console.WriteLine($"Estoque: {filme.Estoque} unidades");
                Console.WriteLine(new string('-', 20));
            }
        }


        public void GerarRelatorioFuncionarios()
        {
            string datasetFuncionarios = File.ReadAllText(caminhoFuncionarios);
            List<Funcionario> listaFuncionarios = Funcionario.ConverterLista(datasetFuncionarios);

            Console.WriteLine("Lista de Funcionários:");
            foreach (var funcionario in listaFuncionarios)
            {
                Console.WriteLine($"ID: {funcionario.Id}");
                Console.WriteLine($"Nome: {funcionario.Nome}");
                Console.WriteLine($"Sobrenome: {funcionario.Sobrenome}");
                Console.WriteLine($"CPF: {funcionario.CPF}");
                Console.WriteLine($"Data de Nascimento: {funcionario.DataNascimento.ToShortDateString()}");
                Console.WriteLine($"Telefone: {funcionario.Telefone}");
                Console.WriteLine($"Email: {funcionario.Email}");
                Console.WriteLine($"Cargo: {funcionario.Cargo}");
                Console.WriteLine($"Salário: R${funcionario.Salario}");
                Console.WriteLine(new string('-', 20));
            }
        }
    }
}
