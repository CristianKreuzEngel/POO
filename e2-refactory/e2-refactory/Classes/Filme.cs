using System;
using Npgsql;

namespace e2_refactory.Classes
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Diretor { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        
        public Filme() { }
        
        public static Filme ObterFilmePorId(int id, Conn conexao)
        {
            Filme filme = null;
            using (var conn = conexao.AbrirConexao())
            {
                string sql = "SELECT * FROM filmes WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            filme = new Filme
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Titulo = reader.GetString(reader.GetOrdinal("titulo")),
                                Genero = reader.GetString(reader.GetOrdinal("genero")),
                                DataLancamento = reader.GetDateTime(reader.GetOrdinal("data_lancamento")),
                                Diretor = reader.GetString(reader.GetOrdinal("diretor")),
                                Preco = reader.GetDecimal(reader.GetOrdinal("preco")),
                                Estoque = reader.GetInt32(reader.GetOrdinal("estoque"))
                            };
                        }
                    }
                }
                conexao.FecharConexao(conn);
            }
            return filme;
        }
        
        public void SalvarFilme(Conn conexao)
        {
            using (var conn = conexao.AbrirConexao())
            {
                string sql = Id == 0
                    ? "INSERT INTO filmes (titulo, genero, data_lancamento, diretor, preco, estoque) VALUES (@titulo, @genero, @data_lancamento, @diretor, @preco, @estoque) RETURNING id"
                    : "UPDATE filmes SET titulo = @titulo, genero = @genero, data_lancamento = @data_lancamento, diretor = @diretor, preco = @preco, estoque = @estoque WHERE id = @id";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("titulo", Titulo);
                    cmd.Parameters.AddWithValue("genero", Genero);
                    cmd.Parameters.AddWithValue("data_lancamento", DataLancamento);
                    cmd.Parameters.AddWithValue("diretor", Diretor);
                    cmd.Parameters.AddWithValue("preco", Preco);
                    cmd.Parameters.AddWithValue("estoque", Estoque);

                    if (Id != 0)
                    {
                        cmd.Parameters.AddWithValue("id", Id);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                conexao.FecharConexao(conn);
            }
        }
    }
}
