using MySql.Data.MySqlClient;
using Prontuario.Classes.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prontuario.Classes.Modelos
{
    public class clsModeloDocumento : ConexaoBanco
    {
        public int codigo { get; set; }
        public string nome { get; set; }

        MySqlDataReader dados = null;

        public clsModeloDocumento(int codigoDocumento)
        {
            try
            {
                string nomeProcedure = "PreencherDocumento";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigo", codigoDocumento.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        this.codigo = codigoDocumento;
                        this.nome = dados[0].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao preencher documento");
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