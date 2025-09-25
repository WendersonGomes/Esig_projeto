using System;
using System.Linq;
using Esig_projeto.App_Code.Models;

namespace Esig_projeto
{
    public partial class _Default : System.Web.UI.Page
    {
        private readonly PessoaRepository _repo = new PessoaRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarCargos();

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    CarregarPessoa(id);
                }
            }
        }

        private void CarregarCargos()
        {
            var cargos = _repo.ListarCargos();
            ddlCargo.DataSource = cargos;
            ddlCargo.DataTextField = "CargoNome";
            ddlCargo.DataValueField = "CargoId";
            ddlCargo.DataBind();
            ddlCargo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Selecione--", "0"));
        }

        private void CarregarPessoa(int id)
        {
            var p = _repo.ObterPorId(id);
            if (p != null)
            {
                txtNome.Text = p.Nome;
                txtCidade.Text = p.Cidade;
                txtEmail.Text = p.Email;
                txtCEP.Text = p.CEP;
                txtEndereco.Text = p.Endereco;
                txtPais.Text = p.Pais;
                txtUsuario.Text = p.Usuario;
                txtTelefone.Text = p.Telefone;
                txtDataNascimento.Text = p.DataNascimento == DateTime.MinValue ? "" : p.DataNascimento.ToString("yyyy-MM-dd");

                ddlCargo.SelectedValue = p.CargoId.ToString();

                var cargo = _repo.ListarCargos().FirstOrDefault(c => c.CargoId == p.CargoId);
                if (cargo != null)
                    txtSalarioBase.Text = cargo.Salario.ToString("F2");
            }
        }

        protected void SalarioBaseAlterado(object sender, EventArgs e)
        {
            int cargoId;
            if (int.TryParse(ddlCargo.SelectedValue, out cargoId) && cargoId != 0)
            {
                var cargo = _repo.ListarCargos().FirstOrDefault(c => c.CargoId == cargoId);
                if (cargo != null)
                    txtSalarioBase.Text = cargo.Salario.ToString("F2");
            }
            else
            {
                txtSalarioBase.Text = "";
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            int id = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : 0;

            var pessoa = new Pessoa
            {
                PessoaId = id,
                Nome = txtNome.Text,
                Cidade = txtCidade.Text,
                Email = txtEmail.Text,
                CEP = txtCEP.Text,
                Endereco = txtEndereco.Text,
                Pais = txtPais.Text,
                Usuario = txtUsuario.Text,
                Telefone = txtTelefone.Text,
                DataNascimento = string.IsNullOrEmpty(txtDataNascimento.Text) ? DateTime.MinValue : DateTime.Parse(txtDataNascimento.Text),
                CargoId = int.Parse(ddlCargo.SelectedValue)
            };

            if (id == 0)
                _repo.Inserir(pessoa);
            else
                _repo.Atualizar(pessoa);

            Response.Redirect("Listar.aspx");
        }
    }
}
