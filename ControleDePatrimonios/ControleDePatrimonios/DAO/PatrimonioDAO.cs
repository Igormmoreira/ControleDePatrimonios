using ControleDePatrimonios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDePatrimonios.Models
{
    public class PatrimonioDAO
    {
        public List<Patrimonio> FindAll()
        {
            List<Patrimonio> patrimonios = new List<Patrimonio>();
            patrimonios.Add(new Patrimonio { Descricao = "Teste da descrição", MarcaID = 1, Nome = "Teste do nome", NumeroTombo = 1, Id = 1 });
            patrimonios.Add(new Patrimonio { Descricao = "Teste da descrição 2", MarcaID = 1, Nome = "Teste do nome 2", NumeroTombo = 1, Id = 2 });
            return patrimonios;
        }

        public void Insert(Patrimonio patrimonio)
        {
            // Implementar
        }

        public Patrimonio FindById(int id)
        {
            // Implementar busca ao invez de criar um novo
            return new Patrimonio { Descricao = "Teste da descrição", MarcaID = 1, Nome = "Teste do nome", NumeroTombo = 1, Id = 1 }; 
        }

        public void Remove(int id)
        {
            Remove(FindById(id));
        }

        public void Remove(Patrimonio patrimonio)
        {
            // Implementar remoção por objeto
        }
    }
}
