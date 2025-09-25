<%@ Page Title="Listar Salários" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="Esig_projeto.Listar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center mt-5">
        <div class="col-12 col-md-11 col-lg-10">
            <h2 class="text-center mb-4">Listagem de Salários</h2>

            <div class="mb-3 text-center">
                <asp:Button ID="btnListarSemCalculo" runat="server" Text="Listar"
                    CssClass="btn btn-secondary me-2" OnClick="btnListarSemCalculo_Click" />

                <asp:Button ID="btnListarComBonus" runat="server" Text="Calcular"
                    CssClass="btn btn-success me-2" OnClick="btnListarComBonus_Click" />
            </div>

            <asp:GridView ID="gvSalarios" runat="server" CssClass="table table-striped table-bordered"
                AutoGenerateColumns="False" DataKeyNames="PessoaId"
                OnRowCommand="gvSalarios_RowCommand">
                <Columns>
                    <asp:BoundField DataField="PessoaId" HeaderText="ID" />
                    <asp:BoundField DataField="PessoaNome" HeaderText="Nome" />
                    <asp:BoundField DataField="CargoNome" HeaderText="Cargo" />
                    <asp:BoundField DataField="Salario" HeaderText="Salário" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="Ações">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlEditar" runat="server"
                                NavigateUrl='<%# "Default.aspx?id=" + Eval("PessoaId") %>'
                                CssClass="btn btn-primary btn-sm">Editar</asp:HyperLink>

                            <asp:Button ID="btnExcluir" runat="server" CommandName="Excluir"
                                CommandArgument='<%# Eval("PessoaId") %>' CssClass="btn btn-danger btn-sm ms-2"
                                Text="Excluir" OnClientClick="return confirm('Deseja realmente excluir?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>
