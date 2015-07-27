<%@ Page Title="Cadastro de cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroCliente.aspx.cs" Inherits="PetControl.Cadastro.CadastroPessoa" %>

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

            <%--<asp:FormView ID="fvCliente" ItemType="PetControl.Models.Cliente" DataKeyNames="PessoaID"
                 runat="server" Visible="true">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td><asp:Label ID="Label1" runat="server" Text="Código"></asp:Label></td>
                            <td><asp:Label ID="Label2" runat="server" Text='<%# Bind("PessoaID") %>' ></asp:Label></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label3" runat="server" Text="Nome"></asp:Label></td>
                            <td><asp:Label ID="Label4" runat="server" Text='<%# Bind("Nome") %>' ></asp:Label></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label5" runat="server" Text="Cpf"></asp:Label></td>
                            <td><asp:Label ID="Label6" runat="server" Text='<%# Bind("Cpf") %>' ></asp:Label></td>
                        </tr>
                    </table>
                </ItemTemplate>

                <EditItemTemplate>
                </EditItemTemplate>
            </asp:FormView>--%>

            <br />
            <br />

            <asp:Button ID="btnInserir" runat="server" Text="Inserir novo cliente" OnClick="btnInserir_Click" CausesValidation="false"
                Enabled="true" Visible="true" />

            <%--<asp:Button ID="btnRemover" runat="server" Text="Remover" OnClick="btnRemover_Click"
                CausesValidation="false" Enabled="false" Visible="false" />

            <asp:Button ID="btnAlterar" runat="server" Text="Alterar" CausesValidation="true" OnClick="btnAlterar_Click"
                Enabled="false" Visible="false" />--%>

            <br />
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

                <div id="contatosPlace" runat="server">
                </div>

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
