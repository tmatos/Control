using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetControl.Models;
using PetControl.Logic;

namespace PetControl.Cadastro
{
    public partial class CadastroCliente2 : System.Web.UI.Page
    {
        private Cliente cliente
        {
            get { return (Cliente)ViewState["cliente"]; }
            set { ViewState["cliente"] = value; }
        }

        private string acao
        {
            get { return (string)ViewState["acao"]; }
            set { ViewState["acao"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }

            if (Page.IsPostBack)
            {
            }
        }

        public Cliente GetCliente(int? id)
        {
            return new PetContext().Cliente.Find(id);
        }

        protected void btnInserirCliente_Click(object sender, EventArgs e)
        {

            SetModoInserirCliente();
        }

        private void SetModoInserirCliente()
        {
            gvClientes.SelectRow(-1);

            btnInserirCliente.Enabled = false;
            pnlClienteDados.Visible = true;

            txtNome.Text = "";
            txtNascimento.Text = "";
            txtCpf.Text = "";

            cliente = new Cliente();
            cliente.Contatos = new List<Contato>();
            cliente.Contatos.Add(new Contato());

            carregaContatosDoCliente();
        }

        private void carregaContatosDoCliente()
        {
            dlContatos.DataSource = cliente.Contatos;
            dlContatos.DataBind();
        }

        //private void carregaContatosDoCliente(Cliente cliente)
        //{
        //    for (int i = 1; i <= cliente.Contatos.Count; i++)
        //    {
        //        //cliente.Contatos.ElementAt<
        //    }

        //    int cont = 1;

        //    foreach (Contato contato in cliente.Contatos)
        //    {
        //        contatosPlace.Controls.Add(new LiteralControl("<br/>"));

        //        Label lblContat = new Label();
        //        lblContat.ID = "lblContato_" + cont;
        //        lblContat.Text = "Contato: " + cont;
        //        //lblContat.Width = 160;
        //        //lblContat.Attributes.Add("style", "color:#015D84;font-weight:bold;font-size:12px;padding:10px;");
        //        lblContat.EnableViewState = true;

        //        contatosPlace.Controls.Add(lblContat);

        //        TextBox txtContato = new TextBox();
        //        txtContato.ID = "txtContato_" + cont;
        //        //txtContato.Width = 160;
        //        txtContato.EnableViewState = true;

        //        contatosPlace.Controls.Add(txtContato);

        //        Button btnRemovContat = new Button();
        //        btnRemovContat.ID = "btnRemoverContato_" + cont;
        //        btnRemovContat.Text = "Remover";

        //        contatosPlace.Controls.Add(btnRemovContat);

        //        cont++;
        //    }
        //}

        protected void btnRemover_Click(object sender, EventArgs e)
        {

        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        protected void btnMaisContato_Click(object sender, EventArgs e)
        {
            cliente.Contatos.Add(new Contato());

            carregaContatosDoCliente();
        }
        
        protected void dlContatos_EditCommand(object source, DataListCommandEventArgs e)
        {
            dlContatos.DataSource = cliente.Contatos;
            dlContatos.EditItemIndex = e.Item.ItemIndex;
            dlContatos.DataBind();
        }

        protected void dlContatos_UpdateCommand(object source, DataListCommandEventArgs e)
        {

            string tipo = ((TextBox)(e.Item.FindControl("txtTipoContato"))).Text;
            string valor = ((TextBox)(e.Item.FindControl("txtValorContato"))).Text;

            cliente.Contatos[e.Item.ItemIndex].Tipo = tipo;
            cliente.Contatos[e.Item.ItemIndex].Valor = valor;

            dlContatos.DataSource = cliente.Contatos;
            dlContatos.EditItemIndex = -1;
            dlContatos.DataBind();
        }

        protected void dlContatos_CancelCommand(object source, DataListCommandEventArgs e)
        {
            dlContatos.DataSource = cliente.Contatos;
            dlContatos.EditItemIndex = -1;
            dlContatos.DataBind();
        }

        protected void removerContato(object sender, DataListCommandEventArgs e)
        {
            cliente.Contatos.RemoveAt(e.Item.ItemIndex);

            carregaContatosDoCliente();
        }

        public IQueryable<Cliente> GetClientes() //[QueryString("id")] int? clienteId)
        {
            return FuncoesPessoas.GetAllClientes();
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvClientes.SelectedIndex < 0)
            {
                return;
            }

            //    fvCliente.ChangeMode(FormViewMode.ReadOnly);

            int id = Convert.ToInt32(gvClientes.SelectedValue);

            //var ds = new PetContext().Pessoa.Where<Pessoa>(p => p.PessoaID == id).ToList<Pessoa>();

            cliente = FuncoesPessoas.GetClienteByKey(id);

            pnlClienteDados.Visible = true;

            txtNome.Text = cliente.Nome;
            txtCpf.Text = cliente.Cpf.ToString();

            dlContatos.DataSource = cliente.Contatos;
            dlContatos.DataBind();

            acao = "ver";

            

            //    fvCliente.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dlContatos.EditItemIndex > -1)
            {
                // Aviso???
            }

            try
            {
                cliente.Nome = txtNome.Text;
                cliente.Cpf = Convert.ToInt64(txtCpf.Text);


                PetContext context = new PetContext();
                context.Pessoa.Add(cliente);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "ERRO: " + ex.Message;
            }
            finally
            {
                cliente = null;

                btnInserirCliente.Enabled = true;
                pnlClienteDados.Visible = false;

                lblStatus.Text = "Cliente adicionado com sucesso.";
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            cliente = null;
            gvClientes.SelectRow(-1);
            btnInserirCliente.Enabled = true;
            pnlClienteDados.Visible = false;
        }
    
    }
}