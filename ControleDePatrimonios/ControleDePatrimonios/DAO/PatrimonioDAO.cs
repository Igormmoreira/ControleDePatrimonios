using ControleDePatrimonios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDePatrimonios.Models
{
    public class PatrimonioDAO
    {
        public List<Patrimonio> Listar()
        {
            List<Patrimonio> patrimonios = new List<Patrimonio>();
            patrimonios.Add(new Patrimonio { Descricao = "Teste da descrição", MarcaID = 1, Nome = "Teste do nome", NumeroTombo = 1 });
            patrimonios.Add(new Patrimonio { Descricao = "Teste da descrição 2", MarcaID = 1, Nome = "Teste do nome 2", NumeroTombo = 1 });
            return patrimonios;
        }

        public void Insert(Patrimonio patrimonio)
        {
            // Implementar
        }
    }
}
