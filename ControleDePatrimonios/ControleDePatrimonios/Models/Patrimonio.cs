using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDePatrimonios.Models
{
    public class Patrimonio
    {
        public string Nome { get; set; }
        public int Id { get; set; }
        public Marca marca { get; set; }
        public int MarcaID { get; set; }
        public string Descricao { get; set; }
        public int NumeroTombo { get; set; }
    }
}
