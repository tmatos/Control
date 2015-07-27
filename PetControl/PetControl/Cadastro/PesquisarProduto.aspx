<%@ Page Title="Localizar um produto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PesquisarProduto.aspx.cs" Inherits="PetControl.Cadastro.PesquisarProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Localizar produto:</h3>

    <table>
        <tr>
            <td><asp:Label ID="lblCategoria" runat="server">Categoria:</asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlCategoria" runat="server" 
                    ItemType="PetControl.Models.Categoria" SelectMethod="GetCategorias" 
                    DataTextField="CategoriaNome" DataValueField="CategoriaID" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblNome" runat="server">Nome:</asp:Label></td>
            <td>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblDescricao" runat="server">Descrição:</asp:Label></td>
            <td>
                <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblPreco" runat="server">Preço:</asp:Label></td>
            <td>
                <asp:TextBox ID="txtPreco" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="* Deve ser um preço válido e sem cifrão." ControlToValidate="txtPreco" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>

    <p></p>
    <p></p>

    <asp:Button ID="btnLocalizar" runat="server" Text="Localizar" OnClick="btnLocalizar_Click"  CausesValidation="true"/>

    <asp:Label ID="lblLocalizarStatus" runat="server" Text=""></asp:Label>

    
    <p></p>
    <p>
        <asp:GridView ID="gvProdutos" runat="server" AllowPaging="True" AutoGenerateColumns="false" EmptyDataText="Sem resultados."
            OnPageIndexChanging="gvProdutos_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Nome" HeaderText="Nome do produto" />
                <asp:BoundField DataField="Preco" HeaderText="Preço Unitário" />
                <asp:BoundField DataField="ComDesconto" HeaderText="Com desconto" />
                <asp:HyperLinkField Text="Modificar" DataNavigateUrlFields="Codigo" DataNavigateUrlFormatString="CadastroProduto.aspx?produtoID={0}&Acao=alterar" />
                <asp:HyperLinkField Text="Excluir" DataNavigateUrlFields="Codigo" DataNavigateUrlFormatString="CadastroProduto.aspx?produtoID={0}&Acao=deletar" />
                <asp:HyperLinkField Text="Ver" DataNavigateUrlFields="Codigo" DataNavigateUrlFormatString="~/ProdutoDetalhes.aspx?produtoID={0}" />
            </Columns>
        </asp:GridView>
    </p>


</asp:Content>
