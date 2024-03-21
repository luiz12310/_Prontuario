using MySql.Data.MySqlClient;
using Prontuario.Classes.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prontuario.Classes.Modelos
{
    public class clsModeloAluno : ConexaoBanco
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        MySqlDataReader dados = null;

        #region PreencherDadosAluno

        public clsModeloAluno(int codigoAluno)
        {
            try
            {
                string nomeProcedure = "PreencherDadosAluno";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigo", codigoAluno.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        this.codigo = codigoAluno;
                        this.nome = dados[0].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao preencher dados do aluno");
            }
            finally
            {
                if (dados != null)
                    if (!dados.IsClosed)
                        dados.Close();
                Desconectar();
            }
        }

        #endregion

        public clsModeloAluno()
        {

        }
    }
}