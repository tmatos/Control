<%@ Page Title="Detalhes do produto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProdutoDetalhes.aspx.cs" Inherits="PetControl.ProdutoDetalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView ID="produtoDetalhes" runat="server"
        ItemType="PetControl.Models.Produto"
        SelectMethod ="GetProduto" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.ProdutoNome %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%#:Item.CaminhoFoto %>" style="border:solid; height:300px" alt="<%#:Item.ProdutoNome %>"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <b>Descrição:</b><br /><%#:Item.Descricao %>
                        <br />
                        <span><b>Preço:</b>&nbsp;<%#: String.Format("{0:c}", Item.PrecoUnitario) %></span>
                        <br />
                        <span><b>Com desconto:</b>&nbsp;<%#: String.Format("{0:c}", Item.PrecoUnitarioComDesconto5) %></span>
                        <br />
                        <span><b>Código do produto:</b>&nbsp;<%#:Item.ProdutoID %></span>
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>