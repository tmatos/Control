<%@ Page Title="Cadastro de Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroCliente2.aspx.cs" Inherits="PetControl.Cadastro.CadastroCliente2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cadastros</h1>
    <hr />
    <h3>Clientes:</h3>
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>

            <asp:GridView ID="gvClientes" runat="server" ItemType="PetControl.Models.Cliente" DataKeyNames="PessoaID"
                AutoGenerateColumns="false" SelectMethod="GetClientes" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Ver" ShowSelectButton="true" />
                    <asp:BoundField DataField="PessoaID" HeaderText="Código" />
                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                    <asp:BoundField DataField="Cpf" HeaderText="Cpf" />
                    <asp:ButtonField Text="Ver" HeaderText="Detalhes" CommandName="Select" />

                </Columns>
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>

            <br />
            <br />

            <asp:Button ID="btnInserirCliente" runat="server" Text="Inserir novo cliente" OnClick="btnInserirCliente_Click" CausesValidation="false"
                Enabled="true" Visible="true" />

            <br />
            <hr />
            <br />

            <asp:Panel ID="pnlClienteDados" Visible="false" runat="server">

                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblNome" runat="server">Nome:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Campo requerido." ControlToValidate="txtNome" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNascimento" runat="server">Data de nascimento:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtNascimento" onkeydown="return jsDecimals(event);" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="* Formato: dd/mm/aaaa." ControlToValidate="txtNascimento" SetFocusOnError="true" Display="Dynamic" ValidationExpression="[0-9]{2}[\/]?[0-9]{2}[\/]?[0-9]{4}"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCpf" runat="server">CPF:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtCpf" onkeydown="return jsDecimals(event);" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Text="* Deve ser um CPF válido com apenas números." ControlToValidate="txtCpf" SetFocusOnError="True" Display="Dynamic" ValidationExpression="[0-9]{11}"></asp:RegularExpressionValidator>
                        </td>
                    </tr>

                </table>

                <br />

                <asp:DataList ID="dlContatos" runat="server" OnDeleteCommand="removerContato" OnEditCommand="dlContatos_EditCommand"
                    OnUpdateCommand="dlContatos_UpdateCommand" OnCancelCommand="dlContatos_CancelCommand">
                    <ItemTemplate>
                        <b>Tipo: </b>
                        <asp:TextBox ID="TextBox1" Enabled="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Tipo") %>'></asp:TextBox>
                        <b>Valor: </b>
                        <asp:TextBox ID="TextBox2" Enabled="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Valor") %>'></asp:TextBox>

                        <asp:Button Text="Editar" CommandName="edit" ID="btnEditarContato" CausesValidation="false" runat="server" />
                        <asp:Button Text="Remover" CommandName="delete" ID="btnRemoveContato" CausesValidation="false" runat="server" />
                        <br />

                    </ItemTemplate>

                    <EditItemTemplate>
                        <b>Tipo: </b>
                        <asp:TextBox ID="txtTipoContato" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Tipo") %>'></asp:TextBox>
                        <b>Valor: </b>
                        <asp:TextBox ID="txtValorContato" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Valor") %>'></asp:TextBox>
                        <asp:Button Text="Salvar" CommandName="update" ID="btnSalvarContato" CausesValidation="false" runat="server" />
                        <asp:Button Text="Cancelar" CommandName="cancel" ID="btnCancelarContato" CausesValidation="false" runat="server" />

                    </EditItemTemplate>
                </asp:DataList>

                <asp:LinkButton ID="lnkMaisContato" runat="server" Text="Acrescentar contato" CausesValidation="false"
                    Enabled="true" Visible="true" OnClick="btnMaisContato_Click" />

                <br />
                <br />
                <br />

                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CausesValidation="true"
                    Enabled="true" Visible="true" OnClick="btnSalvar_Click" />

                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="false"
                    Enabled="true" Visible="true" OnClick="btnCancelar_Click" />

                <br />
                <br />

            </asp:Panel>

            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>

        </ContentTemplate>
    </asp:UpdatePanel>


    <script>
        function jsDecimals(e) {

            var evt = (e) ? e : window.event;
            var key = (evt.keyCode) ? evt.keyCode : evt.which;
            if (key != null) {
                key = parseInt(key, 10);
                if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
                    if (!jsIsUserFriendlyChar(key, "Decimals")) {
                        return false;
                    }
                }
                else {
                    if (evt.shiftKey) {
                        return false;
                    }
                }
            }
            return true;
        }

        // Function to check for user friendly keys  
        //------------------------------------------
        function jsIsUserFriendlyChar(val, step) {
            // Backspace, Tab, Enter, Insert, and Delete  
            if (val == 8 || val == 9 || val == 13 || val == 45 || val == 46) {
                return true;
            }
            // Ctrl, Alt, CapsLock, Home, End, and Arrows  
            if ((val > 16 && val < 21) || (val > 34 && val < 41)) {
                return true;
            }
            if (step == "Decimals") {
                if (val == 190 || val == 110) {  //Check dot key code should be allowed
                    return true;
                }
            }
            // The rest  
            return false;
        }
    </script>

</asp:Content>
