using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetControl.Models;
using System.Web.ModelBinding;

namespace PetControl
{
    public partial class ProdutoDetalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<Produto> GetProduto([QueryString("ProdutoID")] int? ProdutoId)
        {
            var _db = new PetControl.Models.PetContext();

            IQueryable<Produto> query = _db.Produtos;
            if (ProdutoId.HasValue && ProdutoId > 0)
            {
                query = query.Where(p => p.ProdutoID == ProdutoId);
            }
            else
            {
                query = null;
            }

            return query;
        }
    }
}