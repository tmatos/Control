<%@ Page Title="Cadastro de funcionário" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroFuncionario.aspx.cs" Inherits="PetControl.Cadastro.CadastroFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cadastro de funcionários</h2>
    <hr />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>

            <asp:Panel ID="pnlMaster" runat="server">

                <asp:GridView ID="gvFuncionarios" runat="server" AllowPaging="True" PageSize="15"
                    DataKeyNames="PessoaID" ItemType="PetControl.Models.Funcionario"
                    AllowSorting="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True"
                    OnSelectedIndexChanged="gvFuncionarios_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Matrícula" DataField="Matricula" />
                        <asp:BoundField HeaderText="Nome" DataField="Nome" />
                        <asp:BoundField HeaderText="Nascimento" DataField="DataNascimento" />
                        <asp:BoundField HeaderText="Adimissão" DataField="DataAdmissao" />
                        <asp:BoundField HeaderText="Salário" DataField="Salario" />
                    </Columns>
                    <EmptyDataTemplate>Não há funcionários cadastrados.</EmptyDataTemplate>
                </asp:GridView>
                <br />
                <asp:Button ID="btnAddFuncionario" runat="server" Text="Adicionar funcionário"
                    CausesValidation="false" OnClick="btnAddFuncionario_Click" />

            </asp:Panel>

            <asp:Panel ID="pnlDetail" runat="server">

                <%--<asp:FormView ID="fvFuncionarios" runat="server" DataKeyNames="PessoaID" ItemType="PetControl.Models.Funcionario"
                    OnItemCommand="fvFuncionarios_ItemCommand">
                    <ItemTemplate>
                        Nome:
                        <asp:TextBox Text='<%# Bind("Nome") %>' ID="txtEditNome" runat="server"></asp:TextBox>
                        <br />
                        Nascimento:
                        <asp:TextBox Text="" ID="txtNascimento" runat="server"></asp:TextBox>&nbsp;
                        Idade:<asp:TextBox Text='<%# Bind("Idade") %>' ID="TextBox1" runat="server"></asp:TextBox>
                        <br />
                        Matrícula:
                        <asp:TextBox Text='<%# Bind("Matricula") %>' ID="TextBox2" runat="server"></asp:TextBox>
                        <br />
                        Adimissão:
                        <asp:TextBox Text="" ID="TextBox3" runat="server"></asp:TextBox>
                        <br />
                        Salário:
                        <asp:TextBox Text='<%# Bind("Salario") %>' ID="TextBox4" runat="server"></asp:TextBox>
                        <br />
                        
                        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CommandName="Cancel" CausesValidation="false"/> 

                    </ItemTemplate>
                    <InsertItemTemplate>
                        Nome:
                        <asp:TextBox Text='<%# Bind("Nome") %>' ID="txtEditNome" runat="server"></asp:TextBox>
                        <br />
                        Nascimento:
                        <asp:TextBox Text="" ID="txtNascimento" runat="server"></asp:TextBox>
                        <br />
                        Matrícula: <asp:TextBox Text='<%# Bind("Idade") %>' ID="TextBox2" runat="server"></asp:TextBox>
                        <br />
                        Adimissão:
                        <asp:TextBox Text="" ID="TextBox3" runat="server"></asp:TextBox>
                        <br />
                        Salário:
                        <asp:TextBox Text='<%# Bind("Salario") %>' ID="TextBox4" runat="server"></asp:TextBox>
                        <br />
                        
                        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CommandName="Update" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CommandName="Cancel" />

                    </InsertItemTemplate>
                </asp:FormView>--%>
                <table>
                    <tr>
                        <td>Nome:&nbsp;</td>
                        <td>
                            <asp:TextBox MaxLength="100" ID="txtNome" runat="server" ControlToValidate="txtNome"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Requerido" ControlToValidate="txtNome" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>

                    </tr>
                    <tr>
                        <td>Nascimento:&nbsp;</td>
                        <td>
                            <asp:TextBox MaxLength="8" ID="txtNascimento" runat="server"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>Matrícula:&nbsp;</td>
                        <td>
                            <asp:TextBox MaxLength="20" ID="txtMatricula" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Admissão:&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtAdmissao" runat="server" MaxLength="8"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAdmissao" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Salário:&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtSalario" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtSalario"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>

                <br />
                <b>Contatos:</b><br />

                <asp:DataList ID="dlContatos" runat="server" DataKeyField="ContatoID" OnDeleteCommand="dlContatos_DeleteCommand" OnEditCommand="dlContatos_EditCommand"
                    OnUpdateCommand="dlContatos_UpdateCommand" OnCancelCommand="dlContatos_CancelCommand">
                    <ItemTemplate>

                        <table>
                            <tr>
                                <td><b>Tipo:</b> &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="TextBox1" Enabled="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Tipo") %>'></asp:TextBox>&nbsp;</td>
                                <td><b>Valor: </b>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="TextBox2" Enabled="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Valor") %>'></asp:TextBox>&nbsp;</td>
                                <td>
                                    <asp:Button Text="Alterar" CommandName="edit" ID="btnEditarContato" CausesValidation="false" runat="server" />&nbsp;
                                    <asp:Button Text="Remover" CommandName="delete" ID="btnRemoveContato" CausesValidation="false" runat="server" />
                                </td>
                            </tr>
                        </table>
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
                
                <asp:LinkButton ID="lnkAddContato" runat="server" Text="Acrescentar contato" CausesValidation="false"
                    Enabled="true" Visible="true" OnClick="lnkAddContato_Click" />

                <hr />
                
                <asp:Button ID="btnEditar" runat="server" CausesValidation="False" OnClick="btnEditar_Click" Text="Editar" Visible="False" />
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" CausesValidation="false" Visible="False" />
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" CausesValidation="True" Visible="False" />
                <asp:Button ID="btnInserir" runat="server" CausesValidation="True" OnClick="btnInserir_Click" Text="Inserir" Visible="False" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" Visible="False" />

                <asp:Button ID="btnExcluir" runat="server" CausesValidation="False" OnClick="btnExcluir_Click" Text="Excluir" Visible="False" />

            </asp:Panel>

            <br />
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
