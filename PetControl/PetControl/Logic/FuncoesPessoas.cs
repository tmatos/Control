using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetControl.Models;

namespace PetControl.Logic
{
    public static class FuncoesPessoas
    {
        public static bool InserirPessoa(Pessoa zeh)
        {
            using (PetContext _db = new PetContext())
            {
                _db.Pessoa.Add(zeh);
                _db.SaveChanges();
            }

            // Successo
            return true;    
        }

        public static Pessoa GetPessoaByKey(int id)
        {
            return new PetContext().Pessoa.Find(id);
        }

        public static IQueryable<Cliente> GetAllClientes()
        {
            return new PetContext().Cliente;

        }

        public static Cliente GetClienteByKey(int id)
        {
            return new PetContext().Cliente.Find(id);
        }
    }
}