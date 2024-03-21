using MySql.Data.MySqlClient;
using Prontuario.Classes.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Prontuario.Classes.Logica
{
    public class ConexaoBanco
    {

        #region Propriedades

        string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=Remissivas";
        MySqlConnection conexao = null;
        MySqlCommand cSQL = null;

        #endregion

        #region Conectar

        public void Conectar()
        {
            try
            {
                conexao = new MySqlConnection(linhaConexao);
                conexao.Open();
            }
            catch
            {
                throw new Exception("Falha ao conectar ao banco");
            }
        }

        #endregion

        #region Desconectar

        public void Desconectar()
        {
            try
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();
            }
            catch
            {
                throw new Exception("Falha ao desconectar do banco");
            }
        }

        #endregion

        #region Pesquisar

        public MySqlDataReader Pesquisar(string nomeProcedure, List<clsModeloParametro> parametros)
        {
            Conectar();

            try
            {
                cSQL = new MySqlCommand(nomeProcedure, conexao);
                cSQL.CommandType = System.Data.CommandType.StoredProcedure;
                cSQL.Parameters.Clear();

                if (parametros.Count > 0)
                {
                    for (int i = 0; parametros.Count > i; i++)
                    {
                        cSQL.Parameters.AddWithValue(parametros[i].NomeParametro, parametros[i].ValorParametro.ToString());
                    }
                }

                return cSQL.ExecuteReader();
            }
            catch
            {
                throw new Exception("Falha ao excutar comando pesquisar");
            }
        }

        #endregion

        #region Executar

        public void Executar(string nomeProcedure, List<clsModeloParametro> parametros)
        {
            Conectar();

            try
            {
                cSQL = new MySqlCommand(nomeProcedure, conexao);
                cSQL.CommandType = System.Data.CommandType.StoredProcedure;
                cSQL.Parameters.Clear();

                if (parametros.Count > 0)
                {
                    for (int i = 0; parametros.Count > i; i++)
                    {
                        cSQL.Parameters.AddWithValue(parametros[i].NomeParametro, parametros[i].ValorParametro.ToString());
                    }
                }

                cSQL.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Falha ao executar comando executar");
            }
        }

        #endregion
    }
}