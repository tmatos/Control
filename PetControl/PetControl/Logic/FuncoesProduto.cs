using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetControl.Models;

namespace PetControl.Logic
{
    public class FuncoesProduto
    {
        public bool InserirProduto(Produto novoProduto)
        {
            using (PetContext _db = new PetContext())
            {
                _db.Produtos.Add(novoProduto);
                _db.SaveChanges();
            }

            // Successso
            return true;
        }

        public Produto GetProdutoByKey(int id)
        {
            var _db = new PetControl.Models.PetContext();

            return _db.Produtos.Find(id);
        }

        public bool UpdateProduto(Produto novo)
        {
            using (PetContext _db = new PetContext())
            {
                var original = _db.Produtos.Find(novo.ProdutoID);

                if (original != null)
                {
                    original.ProdutoNome = novo.ProdutoNome;
                    original.Descricao = novo.Descricao;
                    original.PrecoUnitario = novo.PrecoUnitario;
                    original.CategoriaID = novo.CategoriaID;
                   _db.SaveChanges();
                }
            }

            // Successso
            return true;
        }
    }
}