using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace EdenDelivery
{
    public class Conexao
    {
        // fabrica e devolve uma conexão JÁ ABERTA
        public MySqlConnection conectarBD()
        {
            MySqlConnection conn;

            string dadosConexao = "Persist Security Info = false; " +
                                  "server = localhost; " +
                                  "database = DB_Delivery; " +
                                  "uid = root; " +
                                  "pwd = ;";

            try
            {
                conn = new MySqlConnection(dadosConexao);
                conn.Open();
                return conn;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Conexão não estabelecida: " + ex.Message);
            }
        }
    }
}
