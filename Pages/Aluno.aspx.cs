using Prontuario.Classes.Logica;
using Prontuario.Classes.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prontuario.Pages
{
    public partial class Aluno : System.Web.UI.Page
    {
        #region Variáveis

        string codigo = "";
        clsLogicaGerenciarAlunos gerenciarAlunos = new clsLogicaGerenciarAlunos();

        #endregion

        #region Load

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(Request["cdAluno"]))
                {
                    codigo = Request["cdAluno"].ToString();

                    if (!IsPostBack)
                    {
                        #region Listar dados básicos aluno

                        List<clsModeloAluno> Aluno = gerenciarAlunos.ListarAlunos(codigo);

                        tblAluno.DataSource = Aluno;
                        tblAluno.DataBind();

                        #endregion

                        #region Listar Documentos

                        List<clsModeloDocumentoAluno> listaDocumentos = gerenciarAlunos.ListarDocumentos(int.Parse(codigo));

                        tblDocumentos.DataSource = listaDocumentos;
                        tblDocumentos.DataBind();

                        if (listaDocumentos.Count == 0)
                        {
                            Response.Redirect("Erro.aspx");
                        }

                        #endregion

                        #region Listar Cursos

                        List<clsModeloProntuario> listaProntuario = gerenciarAlunos.ListarProntuario(int.Parse(codigo));

                        tblCursos.DataSource = listaProntuario;
                        tblCursos.DataBind();

                        #endregion

                        #region Listar Painel Curso

                        string CodigoCurso = "";

                        if (!String.IsNullOrEmpty(Request["cdcurso"]))
                        {
                            CodigoCurso = Request["cdcurso"].ToString();

                            List<clsModeloDiploma> listaDiplomas = gerenciarAlunos.ListarDadosCurso(int.Parse(CodigoCurso), int.Parse(codigo));

                            tblDiploma.DataSource = listaDiplomas;
                            tblDiploma.DataBind();
                            pnlDiploma.Visible = true;
                        }

                        #endregion

                        #region Retirar Diploma

                        if (!String.IsNullOrEmpty(Request["cdDiploma"]) && !String.IsNullOrEmpty(Request["cdcurso"]) && !String.IsNullOrEmpty(Request["cdAluno"]))
                        {
                            string codigoDiploma = Request["cdDiploma"].ToString();

                            gerenciarAlunos.RetirarDiploma(int.Parse(codigo), codigoDiploma, int.Parse(CodigoCurso));


                            //Mensagem de sucesso
                            ListarDiplomas();
                        }

                        #endregion
                    }
                }
                else
                {
                    Response.Redirect("Erro.aspx");
                }
            }
            catch
            {
                Response.Redirect("Erro.aspx");
            }
        }

        #endregion

        #region Listar Diplomas

        public void ListarDiplomas()
        {
            try
            {
                string CodigoCurso = Request["cdcurso"].ToString();

                List<clsModeloDiploma> listaDiplomas = gerenciarAlunos.ListarDadosCurso(int.Parse(CodigoCurso), int.Parse(codigo));

                tblDiploma.DataSource = listaDiplomas;
                tblDiploma.DataBind();
                pnlDiploma.Visible = true;
            }
            catch (Exception erro)
            {
                Response.Redirect("Erro.aspx?erro=" + erro.Message);
            }

        }

        #endregion

        #region Botão Salvar Documentos

        protected void btnDocumento_Click(object sender, EventArgs e)
        {
            try
            {
                codigo = Request["cdAluno"].ToString();

                for (int i = 0; i < tblDocumentos.Rows.Count; i++)
                {
                    string codigoDocumento = (tblDocumentos.Rows[i].Cells[2].Text);
                    bool consta = Boolean.Parse((tblDocumentos.Rows[i].Cells[1].FindControl("chk") as CheckBox).Checked.ToString());

                    gerenciarAlunos.AtualizarDocumentos(int.Parse(codigo), int.Parse(codigoDocumento), consta);
                }
            }
            catch (Exception erro)
            {
                Response.Redirect("Erro.aspx?erro" + erro);
            }
        }

        #endregion

        #region Botão Voltar

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        #endregion

        #region Carregamento dos diplomas

        protected void tblDiploma_Load(object sender, EventArgs e)
        {
            try
            {
                if (tblDiploma.Rows.Count != 0)
                {
                    litEmAndamento.Text = "";

                    for (int i = 0; i < tblDiploma.Rows.Count; i++)
                    {
                        if (tblDiploma.Rows[i].Cells[4].Text == "-")
                        {
                            //btnNovoDiploma.Visible = false;
                            tblDiploma.Rows[i].Cells[5].Visible = true;
                        }
                        else
                        {
                            if (tblDiploma.Rows.Count != 2)
                            {
                                //btnNovoDiploma.Visible = true;
                            }

                            tblDiploma.Rows[i].Cells[5].Enabled = false;
                            tblDiploma.Rows[i].Cells[5].Text = "Retirado";
                        }
                    }
                }
                else
                {
                    litEmAndamento.Text = "Curso em Andamento";
                }
            }
            catch
            {

            }

        }
        #endregion

        protected void tblDiploma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}