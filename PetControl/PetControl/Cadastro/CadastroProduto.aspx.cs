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

    public partial class CadastroProduto : System.Web.UI.Page
    {
        private int id
        {
            get { return (int)ViewState["Id"]; }
            set { ViewState["Id"] = value; }
        }

        private Produto produto
        {
            get { return (Produto)ViewState["Produto"]; }
            set { ViewState["Produto"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string retorno = Request.QueryString["Retorno"];

            if (retorno == "inserido")
            {
                lblStatus.Text = "Produto inserido!";
            }
            else if (retorno == "removido")
            {
                lblStatus.Text = "Produto removido!";
            }
            else if (retorno == "alterado")
            {
                lblStatus.Text = "Produto alterado!";
            }

            if (!Page.IsPostBack)
            {

                String acao = Request.QueryString["Acao"];

                id = 0;

                if (acao == "inserir")
                {
                    produto = new Produto();

                    btnInserirProduto.Enabled = true;
                    btnInserirProduto.Visible = true;

                }
                else
                {
                    id = Convert.ToInt32(Request.QueryString["ProdutoID"]);

                    if (id != 0)
                    {
                        produto = new FuncoesProduto().GetProdutoByKey(id);
                        CarregaCamposFromProduto(produto);
                    }

                    if (acao == "deletar")
                    {

                        btnRemoverProduto.Enabled = true;
                        btnRemoverProduto.Visible = true;
                    }
                    else if (acao == "alterar")
                    {
                        btnAlterarProduto.Enabled = true;
                        btnAlterarProduto.Visible = true;
                    }
                }
            }
        }

        private void CarregaCamposFromProduto(Produto produto)
        {
            if (produto == null)
            {
                lblStatus.Text = "Produto com código " + id.ToString() + ", não localizado.";
                return;
            }

            ddlCategoria.SelectedValue = produto.CategoriaID.ToString();
            txtProdutoNome.Text = produto.ProdutoNome;
            txtDescricao.Text = produto.Descricao;
            txtPreco.Text = produto.PrecoUnitario.ToString();
            //fileCaminhoFoto. = 
        }

        protected void btnInserirProduto_Click(object sender, EventArgs e)
        {
            //Boolean fileOK = false;
            Boolean fileOK = true;

            //String path = Server.MapPath("~/Catalog/Images/");
            //if (fileCaminhoFoto.HasFile)
            //{
            //    String fileExtension = System.IO.Path.GetExtension(fileCaminhoFoto.FileName).ToLower();
            //    String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
            //    for (int i = 0; i < allowedExtensions.Length; i++)
            //    {
            //        if (fileExtension == allowedExtensions[i])
            //        {
            //            fileOK = true;
            //        }
            //    }
            //}

            if (fileOK)
            {
                //try
                //{
                //    // Save to Images folder.
                //    fileCaminhoFoto.PostedFile.SaveAs(path + fileCaminhoFoto.FileName);
                //    // Save to Images/Thumbs folder.
                //    fileCaminhoFoto.PostedFile.SaveAs(path + "Thumbs/" + fileCaminhoFoto.FileName);
                //}
                //catch (Exception ex)
                //{
                //    lblInserirStatus.Text = ex.Message;
                //}

                // Inserir produto no BD
                FuncoesProduto funcoesProduto = new FuncoesProduto();
                Produto novoProduto = CarregaProdutoFromCampos();

                bool sucessoInsercao = funcoesProduto.InserirProduto(novoProduto);

                if (sucessoInsercao)
                {
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Retorno=inserido");
                }
                else
                {
                    lblStatus.Text = "Unable to add new product to database.";
                }
            }
            else
            {
                lblStatus.Text = "Unable to accept file type.";
            }
        }

        private Produto CarregaProdutoFromCampos()
        {
            produto.ProdutoNome = txtProdutoNome.Text;
            produto.Descricao = txtDescricao.Text;
            produto.PrecoUnitario = Convert.ToDouble(txtPreco.Text);
            //produto.CaminhoFoto = fileCaminhoFoto.FileName;
            produto.CategoriaID = Convert.ToInt32(ddlCategoria.SelectedValue);

            return produto;
        }

        public IQueryable GetCategorias()
        {
            var _db = new PetControl.Models.PetContext();
            IQueryable query = _db.Categorias;
            return query;
        }

        public IQueryable GetProdutos()
        {
            var _db = new PetControl.Models.PetContext();
            IQueryable query = _db.Produtos;
            return query;
        }

        protected void btnRemoverProduto_Click(object sender, EventArgs e)
        {
            using (var _db = new PetControl.Models.PetContext())
            {
                //int id = Convert.ToInt32(Request.QueryString["ProdutoID"]);

                var myItem = (from c in _db.Produtos where c.ProdutoID == id select c).FirstOrDefault();

                if (myItem != null)
                {
                    _db.Produtos.Remove(myItem);
                    _db.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?Retorno=removido");
                }
                else
                {
                    lblStatus.Text = "Mão foi possível localizar este produto.";
                }
            }
        }

        protected void btnAlterarProduto_Click(object sender, EventArgs e)
        {
            Produto produto = CarregaProdutoFromCampos();
            FuncoesProduto funcoes = new FuncoesProduto();

            if (funcoes.UpdateProduto(produto) )
            {
                lblStatus.Text = "Dados do produto atualizados com sucesso.";
            }
            else
            {
                lblStatus.Text = "Mão foi possível localizar este produto.";
            }
        }


    }
}