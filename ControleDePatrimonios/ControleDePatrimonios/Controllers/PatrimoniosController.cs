using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControleDePatrimonios.Models;

namespace ControleDePatrimonios.Controllers
{
    public class PatrimoniosController : Controller
    {
        public IActionResult Index()
        {
            //List<Patrimonio> list = _patrimonioServices.FindAll();
            //return View(list);

            List<Patrimonio> patrimonios = new PatrimonioDAO().Listar();

            //List<Patrimonio> patrimonios = new List<Patrimonio>();
            //patrimonios.Add(new Patrimonio { Descricao = "Teste da descrição", MarcaID = 1, Nome = "Teste do nome", NumeroTombo = 1 });
            //patrimonios.Add(new Patrimonio { Descricao = "Teste da descrição 2", MarcaID = 1, Nome = "Teste do nome 2", NumeroTombo = 1 });

            return View(patrimonios); // resultado em View
            // return Json(patrimonios); // resultado em JSON
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ListAllJSon()
        {
            List<Patrimonio> patrimonios = new PatrimonioDAO().Listar();
            return Json(patrimonios);
        }
    }
}
