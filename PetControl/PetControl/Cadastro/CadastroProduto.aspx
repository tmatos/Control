<%@ Page Title="Cadastro de produtos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroProduto.aspx.cs" Inherits="PetControl.Cadastro.CadastroProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Cadastros</h1>
    <hr />
    <h3>Produto:</h3>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblInserirCategoria" runat="server">Categoria:</asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlCategoria" runat="server"
                    ItemType="PetControl.Models.Categoria"
                    SelectMethod="GetCategorias" DataTextField="CategoriaNome"
                    DataValueField="CategoriaID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblInserirNome" runat="server">Nome:</asp:Label></td>
            <td>
                <asp:TextBox ID="txtProdutoNome" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Nome do produto requerido." ControlToValidate="txtProdutoNome" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblInserirDescricao" runat="server">Descrição:</asp:Label></td>
            <td>
                <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Descrição requerida." ControlToValidate="txtDescricao" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblInserirPreco" runat="server">Preço:</asp:Label></td>
            <td>
                <asp:TextBox ID="txtPreco" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Preço requerido." ControlToValidate="txtPreco" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="* Deve ser um preço válido e sem cifrão." ControlToValidate="txtPreco" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCaminhoFoto" runat="server">Foto:</asp:Label></td>
            <td>
                <asp:FileUpload ID="fileCaminhoFoto" runat="server" />
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="* Image path required." ControlToValidate="ProductImage" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
    </table>

    <p></p>
    <p></p>

    <asp:Button ID="btnInserirProduto" runat="server" Text="Inserir Produto" OnClick="btnInserirProduto_Click" CausesValidation="true" 
        Enabled="false" Visible="false"/>

    <%--<p></p>
    <h3>Remover Produto:</h3>
    <table>
        <tr>
            <td><asp:Label ID="lblRemoverProduto" runat="server">Produto:</asp:Label></td>
            <td><asp:DropDownList ID="ddlRemoverProduto" runat="server" ItemType="PetControl.Models.Produto" 
                    SelectMethod="GetProdutos" AppendDataBoundItems="true" 
                    DataTextField="ProdutoNome" DataValueField="ProdutoID" >
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <p></p>--%>

    <asp:Button ID="btnRemoverProduto" runat="server" Text="Remover Produto" OnClick="btnRemoverProduto_Click"
        CausesValidation="false"
        Enabled="false" Visible="false" />

    <asp:Button ID="btnAlterarProduto" runat="server" Text="Alterar Produto" CausesValidation="true" OnClick="btnAlterarProduto_Click"
        Enabled="false" Visible="false" />

    <asp:Label ID="lblStatus" runat="server" Text="" ></asp:Label>

</asp:Content>
