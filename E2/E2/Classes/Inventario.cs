using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using E2.Interfaces;

namespace E2.Classes
{
    public class Inventario : IInventario
    {
        private readonly string caminhoArquivo = @"C:\projects\POO\E2\E2\BancoDeDados\filmes.csv";
        
        public void AdicionarFilme()
        {
            Console.Write("Digite o ID do filme: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do filme: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o gênero do filme: ");
            string genero = Console.ReadLine();

            Console.Write("Digite a data de lançamento (yyyy-MM-dd): ");
            DateTime dataLancamento = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o nome do diretor: ");
            string diretor = Console.ReadLine();

            Console.Write("Digite o preço do filme: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            Console.Write("Digite o estoque do filme: ");
            int estoque = int.Parse(Console.ReadLine());

            var filme = new Filme
            {
                Id = id,
                Titulo = titulo,
                Genero = genero,
                DataLancamento = dataLancamento,
                Diretor = diretor,
                Preco = preco,
                Estoque = estoque
            };

            Console.WriteLine("Filme adicionado com sucesso.");
            
            var filmes = ListarTodosFilmes().ToList();
            filmes.Add(filme);

            using (var writer = new StreamWriter(caminhoArquivo))
            {
                foreach (var f in filmes)
                {
                    writer.WriteLine($"{f.Id},{f.Titulo},{f.Genero},{f.DataLancamento:yyyy-MM-dd},{f.Diretor},{f.Preco},{f.Estoque}");
                }
            }
        }

        public void RemoverFilme()
        {
            Console.Write("Digite o ID do filme a ser removido: ");
            int id = int.Parse(Console.ReadLine());
            
            var filmes = ListarTodosFilmes().ToList();
            var filmeParaRemover = filmes.FirstOrDefault(f => f.Id == id);
            Console.WriteLine("Filme removido com sucesso.");
            if (filmeParaRemover != null)
            {
                filmes.Remove(filmeParaRemover);

                using (var writer = new StreamWriter(caminhoArquivo))
                {
                    foreach (var f in filmes)
                    {
                        writer.WriteLine($"{f.Id},{f.Titulo},{f.Genero},{f.DataLancamento:yyyy-MM-dd},{f.Diretor},{f.Preco},{f.Estoque}");
                    }
                }
            }
        }

        public IFilme ConsultarFilme(int filmeId)
        {
            return ListarTodosFilmes().FirstOrDefault(f => f.Id == filmeId);
        }

        public IEnumerable<IFilme> ListarTodosFilmes()
        {
            var filmes = new List<Filme>();

            if (File.Exists(caminhoArquivo))
            {
                var linhas = File.ReadAllLines(caminhoArquivo);

                foreach (var linha in linhas.Skip(1))
                {
                    var dados = linha.Split(',');

                    if (dados.Length == 7 &&
                        int.TryParse(dados[0], out int id) &&
                        DateTime.TryParse(dados[3], out DateTime dataLancamento) &&
                        decimal.TryParse(dados[5], out decimal preco) &&
                        int.TryParse(dados[6], out int estoque))
                    {
                        var filme = new Filme
                        {
                            Id = id,
                            Titulo = dados[1],
                            Genero = dados[2],
                            DataLancamento = dataLancamento,
                            Diretor = dados[4],
                            Preco = preco,
                            Estoque = estoque
                        };

                        filmes.Add(filme);
                    }
                }
            }

            return filmes;
        }
    }
}
