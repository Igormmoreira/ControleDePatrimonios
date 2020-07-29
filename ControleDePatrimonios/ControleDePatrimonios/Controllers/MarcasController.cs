using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControleDePatrimonios.Models;

namespace ControleDePatrimonios.Controllers
{
    public class MarcasController : Controller
    {
        public IActionResult Index()
        {
            List<Marca> marca = new List<Marca>();
            marca.Add(new Marca { MarcaId = 1, Nome = "Teste do nome" });
            marca.Add(new Marca { MarcaId = 2 , Nome = "Teste do nome 2" });
            return View(marca);
        }
    }
}
