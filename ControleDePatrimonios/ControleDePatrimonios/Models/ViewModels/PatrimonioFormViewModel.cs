using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDePatrimonios.Models.ViewModels
{
    public class PatrimonioFormViewModel
    {
        public Patrimonio Patrimonio { get; set; }
        public ICollection<Marca> Marcas { get; set; }
    }
}
