using Esig_projeto.App_Code.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Esig_projeto
{
    public partial class Listar : System.Web.UI.Page
    {
        private readonly PessoaRepository _repo = new PessoaRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarGridSemCalculo();
            }
        }

        protected void btnListarSemCalculo_Click(object sender, EventArgs e)
        {
            CarregarGridSemCalculo();
        }

        protected void btnListarComBonus_Click(object sender, EventArgs e)
        {
            CarregarGridComBonus();
        }
        protected void gvSalarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                _repo.Excluir(id);
                CarregarGridSemCalculo();
            }
        }

        private void CarregarGridSemCalculo()
        {
            var lista = _repo.ListarSalariosSemBonus();
            gvSalarios.DataSource = lista;
            gvSalarios.DataBind();
        }

        private void CarregarGridComBonus()
        {
            var lista = _repo.ListarSalariosComBonus();
            gvSalarios.DataSource = lista;
            gvSalarios.DataBind();
        }
    }
}
