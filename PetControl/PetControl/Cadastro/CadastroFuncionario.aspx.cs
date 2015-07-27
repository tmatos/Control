using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetControl.Models;
using PetControl.Logic;
using System.Globalization;

namespace PetControl.Cadastro
{
    public partial class CadastroFuncionario : System.Web.UI.Page
    {
        Funcionario funcionario
        {
            get { return (Funcionario)ViewState["funcionario"]; }
            set { ViewState["funcionario"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetModoBuscaFuncionario();
            }
        }

        private void SetModoBuscaFuncionario()
        {
            funcionario = null;

            pnlMaster.Visible = true;
            pnlDetail.Visible = false;

            gvFuncionarios.DataSource = new PetContext().Funcionario.ToList();
            gvFuncionarios.SelectedIndex = -1;
            gvFuncionarios.DataBind();
        }

        protected void btnAddFuncionario_Click(object sender, EventArgs e)
        {
            SetModoAddFuncionario();
        }

        private void SetModoAddFuncionario()
        {
            pnlMaster.Visible = false;
            pnlDetail.Visible = true;

            btnInserir.Visible = true;
            btnCancelar.Visible = true;

            funcionario = new Funcionario();
            funcionario.Contatos.Add(new Contato());

            CarregaContatos();
        }

        private void SetModoEditFuncionario(int id)
        {
            pnlMaster.Visible = false;
            pnlDetail.Visible = true;

            try
            {
                btnSalvar.Visible = true;
                btnCancelar.Visible = true;

                btnEditar.Visible = false;
                btnVoltar.Visible = false;

                funcionario = new PetContext().Funcionario.Where(p => p.PessoaID == id).First();

                preencherCamposFromObjeto(funcionario);
                CarregaContatos();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erro: " + ex.Message;
            }
        }

        private void CarregaContatos()
        {
            dlContatos.DataSource = funcionario.Contatos;
            dlContatos.DataBind();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroFuncionario");
        }

        private void preencherCamposFromObjeto(Funcionario f)
        {
            txtNome.Text = f.Nome;
            txtNascimento.Text = f.DataNascimento.ToString("ddMMyyyy", CultureInfo.InvariantCulture);
            txtMatricula.Text = f.Matricula.ToString();
            txtSalario.Text = f.Salario.ToString();
            txtAdmissao.Text = f.DataAdmissao.ToString("ddMMyyyy", CultureInfo.InvariantCulture);
        }

        private void preencherFromCampos(ref Funcionario f)
        {
            f.Nome = txtNome.Text;
            f.DataNascimento = DateTime.ParseExact(txtNascimento.Text, "ddMMyyyy", CultureInfo.InvariantCulture);
            f.Matricula = Convert.ToInt32(txtMatricula.Text);
            f.Salario = Convert.ToDouble(txtSalario.Text);
            f.DataAdmissao = DateTime.ParseExact(txtAdmissao.Text, "ddMMyyyy", CultureInfo.InvariantCulture);
            f.Contatos = funcionario.Contatos;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                PetContext ctx = new PetContext();

                Funcionario f = ctx.Funcionario.Find(funcionario.PessoaID);

                if(f != null)
                {
                    preencherFromCampos(ref f);

                    ctx.SaveChanges();
                }
                else
                {
                    lblStatus.Text = "Funcionário não mais localizado no banco de dados.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erro: " + ex.Message;
            }
            finally
            {
                SetModoAddFuncionario();
            }
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                PetContext ctx = new PetContext();

                Funcionario f = new Funcionario();

                preencherFromCampos(ref f);

                ctx.Funcionario.Add(f);
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                lblStatus.Text = "Erro: " + ex.Message;
            }
            finally
            {
                SetModoAddFuncionario();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroFuncionario");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            SetModoEditFuncionario(funcionario.PessoaID);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                PetContext ctx = new PetContext();

                Funcionario f = ctx.Funcionario.Find(funcionario.PessoaID);

                if(f != null)
                {
                    //foreach(Contato c in f.Contatos)
                    //{
                    ////    ctx.Contato.Re
                    //}
                    //ctx.Contato.Where(c => c. == i).ToList().ForEach(obj.tblA.DeleteObject);

                    ctx.Funcionario.Remove(f);
                    ctx.SaveChanges();
                }
                else
                {
                    lblStatus.Text = "Funcionário não mais localizado no banco de dados.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erro: " + ex.Message;
            }
            finally
            {
                SetModoAddFuncionario();
            }
        }

        protected void dlContatos_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            funcionario.Contatos.RemoveAt(e.Item.ItemIndex);
            CarregaContatos();
        }

        protected void dlContatos_EditCommand(object source, DataListCommandEventArgs e)
        {
            dlContatos.DataSource = funcionario.Contatos;
            dlContatos.EditItemIndex = e.Item.ItemIndex;
            dlContatos.DataBind();
        }

        protected void dlContatos_UpdateCommand(object source, DataListCommandEventArgs e)
        {

            string tipo = ((TextBox)(e.Item.FindControl("txtTipoContato"))).Text;
            string valor = ((TextBox)(e.Item.FindControl("txtValorContato"))).Text;

            funcionario.Contatos[e.Item.ItemIndex].Tipo = tipo;
            funcionario.Contatos[e.Item.ItemIndex].Valor = valor;

            dlContatos.DataSource = funcionario.Contatos;
            dlContatos.EditItemIndex = -1;
            dlContatos.DataBind();
        }

        protected void dlContatos_CancelCommand(object source, DataListCommandEventArgs e)
        {
            dlContatos.DataSource = funcionario.Contatos;
            dlContatos.EditItemIndex = -1;
            dlContatos.DataBind();
        }

        protected void lnkAddContato_Click(object sender, EventArgs e)
        {
            funcionario.Contatos.Add(new Contato());
            CarregaContatos();
        }

        protected void gvFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvFuncionarios.SelectedIndex < 0)
                return;

            int id = Convert.ToInt32(gvFuncionarios.SelectedValue);

            SetModoViewFuncionario(id);
        }

        private void SetModoViewFuncionario(int id)
        {
            pnlMaster.Visible = false;
            pnlDetail.Visible = true;

            try
            {
                btnEditar.Visible = true;
                btnVoltar.Visible = true;

                btnSalvar.Visible = false;
                btnCancelar.Visible = false;

                btnExcluir.Visible = true;

                funcionario = new PetContext().Funcionario.Where(p => p.PessoaID == id).First();

                preencherCamposFromObjeto(funcionario);
                CarregaContatos();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erro: " + ex.Message;
            }
        }

    }
}