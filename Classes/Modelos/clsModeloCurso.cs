using MySql.Data.MySqlClient;
using Prontuario.Classes.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prontuario.Classes.Modelos
{
    public class clsModeloCurso : ConexaoBanco
    {
        public int codigo { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }

        MySqlDataReader dados = null;

        public clsModeloCurso(int codigoCurso)
        {
            try
            {
                string nomeProcedure = "PreencherCurso";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigo", codigoCurso.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        this.codigo = codigoCurso;
                        this.nome = dados[0].ToString();
                        this.sigla = dados[1].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar prontuário");
            }
            finally
            {
                if (dados != null)
                    if (!dados.IsClosed)
                        dados.Close();
                Desconectar();
            }
        }
    }
}