using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControleDePatrimonios.Models;
using ControleDePatrimonios.Models.ViewModels;

namespace ControleDePatrimonios.Controllers
{
    public class PatrimoniosController : Controller
    {
        public IActionResult Index()
        {
            //List<Patrimonio> list = _patrimonioServices.FindAll();
            //return View(list);

            List<Patrimonio> patrimonios = new PatrimonioDAO().FindAll();

            //List<Patrimonio> patrimonios = new List<Patrimonio>();
            //patrimonios.Add(new Patrimonio { Descricao = "Teste da descrição", MarcaID = 1, Nome = "Teste do nome", NumeroTombo = 1 });
            //patrimonios.Add(new Patrimonio { Descricao = "Teste da descrição 2", MarcaID = 1, Nome = "Teste do nome 2", NumeroTombo = 1 });

            return View(patrimonios); // resultado em View
            // return Json(patrimonios); // resultado em JSON
        }

        public IActionResult Create()
        {
            MarcaDAO dao = new MarcaDAO();
            List<Marca> list = dao.FindAll();
            PatrimonioFormViewModel viewData = new PatrimonioFormViewModel { Marcas = list };
            return View(viewData);
        }

        public IActionResult ListAllJSon()
        {
            List<Patrimonio> patrimonios = new PatrimonioDAO().FindAll();
            return Json(patrimonios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patrimonio patrimonios)
        {
            PatrimonioDAO dao = new PatrimonioDAO();
            dao.Insert(patrimonios);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
  
            // Verificar se o int é válido
            
            // PatrimonioDAO dao = new PatrimonioDAO();
            // Patrimonio patrimonio = dao.FindById(id);

            // Verificar se o patrimonio não é nulo;

            // Apagar a instanciação abaixo;
            Patrimonio patrimonio = new Patrimonio { Descricao = "Teste da descrição", MarcaID = 1, Nome = "Teste do nome", NumeroTombo = 1, Id = 1 };
            return View(patrimonio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            PatrimonioDAO dao = new PatrimonioDAO();
            dao.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
