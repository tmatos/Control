using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetControl.Models;
using PetControl.Logic;
using System.Web.ModelBinding;

namespace PetControl.Cadastro
{
    public partial class CadastroPessoa : System.Web.UI.Page
    {

        private Cliente cliente
        {
            get { return (Cliente)ViewState["cliente"]; }
            set { ViewState["cliente"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }

            if (Page.IsPostBack)
            {
                if(cliente != null)
                {
                    AtualizaContatosFromCampos();
                }
            }
        }

        private void AtualizaContatosFromCampos()
        {
            int i = 1;
            foreach (Contato contato in cliente.Contatos)
            {
                contato.Valor = Request.Form["txtContato_" + i.ToString()].ToString();

                i++;
            }
        }

        public Cliente GetCliente(int? id)
        {
            return new PetContext().Cliente.Find(id);
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            SetModoInserirCliente();
        }

        private void SetModoInserirCliente()
        {
            gvClientes.SelectRow(-1);

            pnlClienteDados.Visible = true;

            txtNome.Text = "";
            txtNascimento.Text = "";
            txtCpf.Text = "";

            cliente = new Cliente();
            cliente.Contatos = new List<Contato>();
            cliente.Contatos.Add(new Contato());

            carregaContatosDoCliente(cliente);
        }

        private void carregaContatosDoCliente(Cliente cliente)
        {
            int cont = 1;

            foreach(Contato contato in cliente.Contatos)
            {
                contatosPlace.Controls.Add(new LiteralControl("<br/>"));

                Label lblContat = new Label();
                lblContat.ID = "lblContato_" + cont;
                lblContat.Text = "Contato " + cont + ":";
                //lblContat.Width = 160;
                //lblContat.Attributes.Add("style", "color:#015D84;font-weight:bold;font-size:12px;padding:10px;");
                //lblContat.EnableViewState = true;

                contatosPlace.Controls.Add(lblContat);

                //TextBox txtContato = new TextBox();
                //txtContato.ID = "txtContato_" + cont;
                //txtContato.Text = contato.Valor;
                ////txtContato.Width = 160;
                ////txtContato.EnableViewState = true;

                System.Web.UI.HtmlControls.HtmlInputText txtContato = new System.Web.UI.HtmlControls.HtmlInputText();
                txtContato.ID = "txtContato_" + cont;
                txtContato.Value = contato.Valor;
                //txtContato.Width = 160;
                //txtContato.EnableViewState = true;

                contatosPlace.Controls.Add(txtContato);

                Button btnRemovContat = new Button();
                btnRemovContat.ID = "btnRemoverContato_" + cont;
                btnRemovContat.Click += btnRemovContat_Click;
                btnRemovContat.Text = "Remover";
                btnRemovContat.CausesValidation = false;

                contatosPlace.Controls.Add(btnRemovContat);

                cont++;
            }
        }

        protected void btnRemovContat_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.ID.Split('_')[1]);

            cliente.Contatos.RemoveAt(index);

            carregaContatosDoCliente(cliente);
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {

        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        protected void btnMaisContato_Click(object sender, EventArgs e)
        {
            cliente.Contatos.Add(new Contato());

            carregaContatosDoCliente(cliente);
        }

        public IQueryable<Cliente> GetClientes() //[QueryString("id")] int? clienteId)
        {
            return FuncoesPessoas.GetAllClientes();
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    if(gvClientes.SelectedIndex < 0)
        //    {
        //        return;
        //    }

        //    fvCliente.ChangeMode(FormViewMode.ReadOnly);

        //    int id = Convert.ToInt32(gvClientes.SelectedValue);

        //    var ds = new PetContext().Pessoa.Where<Pessoa>(p => p.PessoaID == id).ToList<Pessoa>();

        //    fvCliente.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            cliente = null;

            pnlClienteDados.Visible = false;
        }
    }
}