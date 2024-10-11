using e2_refactory.Classes;
using System;
using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Database=locacoes7-3;Username=postgres;Password=masterkey";
        
        Conn conexao = new Conn(connectionString);
        
        Filme filme = Filme.ObterFilmePorId(1, conexao);
        if (filme != null)
        {
            Console.WriteLine($"Filme encontrado: {filme.Titulo}");
        }
        else
        {
            Console.WriteLine("Filme não encontrado.");
        }
        
        Filme novoFilme = new Filme
        {
            Titulo = "O Senhor dos Anéis",
            Genero = "Fantasia",
            DataLancamento = new DateTime(2001, 12, 19),
            Diretor = "Peter Jackson",
            Preco = 29.99m,
            Estoque = 10
        };

        novoFilme.SalvarFilme(conexao);
        Console.WriteLine($"Filme salvo com sucesso! ID: {novoFilme.Id}");
    }
}

