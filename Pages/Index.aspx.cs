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
    public partial class Index : System.Web.UI.Page
    {
        clsLogicaGerenciarAlunos gerenciarAluno = new clsLogicaGerenciarAlunos();

        #region Load

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string nomeRequest = "";

                if (!String.IsNullOrEmpty(Request["nome"]))
                {
                    nomeRequest = Request["nome"].ToString();
                }

                List<clsModeloAluno> listaAlunos = gerenciarAluno.ListarAlunos(nomeRequest);
                tblAluno.DataSource = listaAlunos;
                tblAluno.DataBind();
            }
            catch (Exception erro)
            {
                Response.Redirect("Erro.aspx?erro=" + erro);
            }
        }

        #endregion

        #region Botão Buscar

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtFiltro.Text;

                List<clsModeloAluno> listaAlunos = gerenciarAluno.ListarAlunos(filtro);
                tblAluno.DataSource = listaAlunos;
                tblAluno.DataBind();
            }
            catch (Exception erro)
            {
                Response.Redirect("Erro.aspx?erro" + erro);
            }
        }

        #endregion
    }
}