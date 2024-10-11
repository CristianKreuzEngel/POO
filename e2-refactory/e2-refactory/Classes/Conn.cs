using System;
using Npgsql;

namespace e2_refactory.Classes
{
    public class Conn
    {
        private readonly string _connectionString;

        public Conn(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NpgsqlConnection AbrirConexao()
        {
            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public void FecharConexao(NpgsqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}