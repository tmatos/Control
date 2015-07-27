using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetControl.Models;

namespace PetControl.Cadastro
{
    public partial class PesquisarProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {

            }

            //ddlCategoria.Items.Insert(0, new ListItem("", "0"));
        }

        //public IQueryable GetCategorias()
        //{
        //    var _db = new PetControl.Models.ProdutoContext();
        //    IQueryable query = _db.Categorias;
        //    return query;
        //}

        public IList<Categoria> GetCategorias()
        {
            var _db = new PetControl.Models.PetContext();

            IList<Categoria> list = _db.Categorias.ToList<Categoria>();

            Categoria nulo = new Categoria();
            nulo.CategoriaID = 0;
            nulo.CategoriaNome = "";

            list.Insert(0, nulo);

            return list;
        }

        protected void btnLocalizar_Click(object sender, EventArgs e)
        {
            fillGrid();

            //IQueryable<Produto> query;

            //query = query.Where( p => p.ProdutoNome.Contains(txtNome.Text) );

            //gvProdutos.DataSource = query.ToList<Produto>();

            //if (categoriaId.HasValue && categoriaId > 0)
            //{
            //    query = query.Where(p => p.CategoriaID == categoriaId);
            //}
        }

        protected void gvProdutos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProdutos.PageIndex = e.NewPageIndex;
            fillGrid();
        }

        private void fillGrid()
        {
            var _db = new PetControl.Models.PetContext();

            //filtros
            string nome = txtNome.Text;
            int categoria = Convert.ToInt32(ddlCategoria.SelectedValue);

            var results = (from p in _db.Produtos
                           where p.ProdutoNome.Contains(nome)
                              && ( p.CategoriaID == categoria || categoria == 0 )
                           select new
                           {
                               Codigo = p.ProdutoID,
                               Nome = p.ProdutoNome,
                               Preco = p.PrecoUnitario,
                               ComDesconto = p.PrecoUnitario * 0.95
                           }).ToList();

            gvProdutos.DataSource = results;
            gvProdutos.DataBind();
        }
    }
}