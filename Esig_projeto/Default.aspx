<%@ Page Title="Criar/Editar pessoa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Esig_projeto._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container mt-5">
            <h2 class="text-center mb-4">Criar/Editar Pessoas</h2>

            <div class="row g-2">
                <div class="col-12 d-flex justify-content-center">
                    <asp:TextBox ID="txtNome" runat="server" Placeholder="Nome" CssClass="form-control w-50" />
                </div>
                <div class="col-12 d-flex justify-content-center">
                    <asp:TextBox ID="txtCidade" runat="server" Placeholder="Cidade" CssClass="form-control w-50" />
                </div>
                <div class="col-12 d-flex justify-content-center">
                    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" CssClass="form-control w-50" />
                </div>
                <div class="col-12 d-flex justify-content-center">
                    <asp:TextBox ID="txtCEP" runat="server" Placeholder="CEP" CssClass="form-control w-50" />
                </div>
                <div class="col-12 d-flex justify-content-center">
                    <asp:TextBox ID="txtEndereco" runat="server" Placeholder="Endereço" CssClass="form-control w-50" />
                </div>
                <div class="col-12 d-flex justify-content-center">
                    <asp:TextBox ID="txtPais" runat="server" Placeholder="País" CssClass="form-control w-50" />
                </div>
                <div class="col-12 d-flex justify-content-center">
                    <asp:TextBox ID="txtUsuario" runat="server" Placeholder="Usuário" CssClass="form-control w-50" />
                </div>
                <div class="col-12 d-flex justify-content-center">
                    <asp:TextBox ID="txtTelefone" runat="server" Placeholder="Telefone" CssClass="form-control w-50" />
                </div>
                <div class="col-12 d-flex justify-content-center">
                    <asp:TextBox ID="txtDataNascimento" runat="server" Placeholder="Data Nascimento yyyy-mm-dd" CssClass="form-control w-50" />
                </div>
                <div class="col-12 d-flex justify-content-center">
                    <asp:TextBox ID="txtSalarioBase" runat="server" Placeholder="Salário Base"
                        CssClass="form-control w-50" ReadOnly="true" />
                </div>
                <div class="col-12 d-flex justify-content-center">
                    <asp:DropDownList ID="ddlCargo" runat="server" CssClass="form-select w-50"
                        AutoPostBack="true" OnSelectedIndexChanged="SalarioBaseAlterado" />
                </div>
            </div>
            <div class="text-center">
                <asp:Label ID="erro_mensagem" runat="server" Text="" />
            </div>
            <div class="mt-4 text-center">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success me-2" OnClick="BtnSalvar_Click" />
                <asp:HyperLink ID="hlVoltar" runat="server" NavigateUrl="Listar.aspx" CssClass="btn btn-secondary">Ver lista</asp:HyperLink>
            </div>
        </div>
    </main>
</asp:Content>
