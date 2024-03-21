using MySql.Data.MySqlClient;
using Prontuario.Classes.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prontuario.Classes.Modelos
{
    public class clsModeloDiploma : ConexaoBanco
    {
        public string codigoDiploma { get; set; }
        public string segundaVia { get; set; }
        public string codigoLivro { get; set; }
        public string codigoPagina { get; set; }
        public string dataConclusao { get; set; }
        public string dataEmissao { get; set; }
        public string dataRetirada { get; set; }
        public clsModeloCurso Curso { get; set; }
        public clsModeloAluno Aluno { get; set; }

        public int codigoCurso { get; set; }
        public int codigoAluno { get; set; }

        MySqlDataReader dados = null;

        public clsModeloDiploma()
        {

        }

        public void DarSegundaVia(int codigoAluno, string codigoDiploma, int codigoCurso)
        {
            try
            {
                string nomeProcedure = "DarSegundaVia";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigoAluno", codigoAluno.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoDiploma", codigoDiploma));
                parametros.Add(new clsModeloParametro("vCodigoCurso", codigoCurso.ToString()));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao gerar segunda via");
            }
            finally
            {
                Desconectar();
            }
        }

        public clsModeloDiploma(int codigoAluno, int codigoCurso)
        {
            try
            {
                string nomeProcedure = "PreencherDiploma";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigoAluno", codigoAluno.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoCurso", codigoCurso.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        this.Aluno = new clsModeloAluno(codigoAluno);
                        this.Curso = new clsModeloCurso(codigoCurso);

                        this.codigoAluno = codigoAluno;
                        this.codigoCurso = codigoCurso;
                        this.codigoDiploma = dados[2].ToString();
                        this.codigoLivro = dados[3].ToString();
                        this.codigoPagina = dados[4].ToString();

                        //Datas

                        if (String.IsNullOrEmpty(dados[5].ToString()))
                            this.dataConclusao = "-";
                        else
                            this.dataConclusao = DateTime.Parse(dados[5].ToString()).ToString("dd/MM/yyyy");

                        if (String.IsNullOrEmpty(dados[6].ToString()))
                            this.dataEmissao = "-";
                        else
                            this.dataEmissao = DateTime.Parse(dados[6].ToString()).ToString("dd/MM/yyyy");

                        if (String.IsNullOrEmpty(dados[7].ToString()))
                            this.dataRetirada = "-";
                        else
                            this.dataRetirada = DateTime.Parse(dados[7].ToString()).ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao preencher diploma");
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