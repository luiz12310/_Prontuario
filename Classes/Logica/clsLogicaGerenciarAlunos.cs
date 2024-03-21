using MySql.Data.MySqlClient;
using Prontuario.Classes.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Prontuario.Classes.Logica
{
    public class clsLogicaGerenciarAlunos : ConexaoBanco
    {
        MySqlDataReader dados = null;

        #region Listar Alunos

        public List<clsModeloAluno> ListarAlunos(string nomePesquisa)
        {
            List<clsModeloAluno> listaAlunos = new List<clsModeloAluno>();

            try
            {
                string nomeProcedure = "ListarAlunos";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vPesquisa", nomePesquisa));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        clsModeloAluno aluno = new clsModeloAluno(int.Parse(dados[0].ToString()));
                        listaAlunos.Add(aluno);
                    }
                }

                return listaAlunos;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar alunos");
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

        #region Listar Documentos

        public List<clsModeloDocumentoAluno> ListarDocumentos(int codigoAluno)
        {
            List<clsModeloDocumentoAluno> listaDocumentos = new List<clsModeloDocumentoAluno>();

            try
            {
                string nomeProcedure = "ListarDocumentos";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigo", codigoAluno.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        clsModeloDocumentoAluno documentoAluno = new clsModeloDocumentoAluno(int.Parse(dados[0].ToString()), int.Parse(dados[1].ToString()), Boolean.Parse(dados[2].ToString()));
                        listaDocumentos.Add(documentoAluno);
                    }
                }

                return listaDocumentos;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar documentos");
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

        #region Listar Prontuario
        public List<clsModeloProntuario> ListarProntuario(int codigoAluno)
        {
            List<clsModeloProntuario> listaProntuario = new List<clsModeloProntuario>();

            try
            {
                string nomeProcedure = "ListarProntuario";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigo", codigoAluno.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        clsModeloProntuario prontuario = new clsModeloProntuario(int.Parse(dados[0].ToString()), int.Parse(dados[1].ToString()), dados[2].ToString());
                        listaProntuario.Add(prontuario);
                    }
                }

                return listaProntuario;
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

        #endregion

        #region Listar Dados Curso

        public List<clsModeloDiploma> ListarDadosCurso(int codigoCurso, int codigoAluno)
        {
            List<clsModeloDiploma> listaDiplomas = new List<clsModeloDiploma>();

            try
            {
                string nomeProcedure = "ListarDadosCurso";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigoCurso", codigoCurso.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoAluno", codigoAluno.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        clsModeloDiploma diploma = new clsModeloDiploma(int.Parse(dados[0].ToString()), int.Parse(dados[1].ToString()));
                        listaDiplomas.Add(diploma);
                    }
                }

                return listaDiplomas;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar diploma");
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

        #region Atualizar Documentos

        public void AtualizarDocumentos(int codigoAluno, int codigoDocumento, bool consta)
        {
            try
            {
                string nomeProcedure = "AtualizarDocumentos";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigoAluno", codigoAluno.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoDocumento", codigoDocumento.ToString()));
                parametros.Add(new clsModeloParametro("vConsta", consta.ToString()));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao atualizar documentos");
            }
            finally
            {
                Desconectar();
            }
        }

        #endregion

        #region Retirar Diploma

        public void RetirarDiploma(int codigoAluno, string codigoDiploma, int codigoCurso)
        {
            try
            {
                string nomeProcedure = "RetirarDiploma";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigoAluno", codigoAluno.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoDiploma", codigoDiploma.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoCurso", codigoCurso.ToString()));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao retirar diploma");
            }
            finally
            {
                Desconectar();
            }
        }

        #endregion

        #region Criar Diploma

        public void CriarDiploma(int codigoAluno, int codigoCurso, string codigoDiploma, string codigoLivro, string codigoPagina, string dataConclusao, string dataEmissao)
        {
            try
            {
                string nomeProcedure = "CriarDiploma";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigoAluno", codigoAluno.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoCurso", codigoCurso.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoDiploma", codigoDiploma.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoLivro", codigoLivro.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoPagina", codigoPagina.ToString()));
                parametros.Add(new clsModeloParametro("vDataConclusao", dataConclusao.ToString()));
                parametros.Add(new clsModeloParametro("vDataEmissao", dataEmissao.ToString()));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao criar diploma");
            }
            finally
            {
                Desconectar();
            }
        }

        #endregion
    }
}