using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ControleDePatrimonios.Models;
using ControleDePatrimonios.Models.ViewModels;

namespace ControleDePatrimonios.Controllers
{
    public class PatrimoniosController : Controller
    {
        public IActionResult Index()
        {
            List<Patrimonio> patrimonios = new PatrimonioDAO().FindAll();

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
        public IActionResult Create(PatrimonioFormViewModel patrimonios)
        {
            PatrimonioDAO dao = new PatrimonioDAO();
            patrimonios.Patrimonio = dao.Insert(patrimonios.Patrimonio);

            return Json(patrimonios.Patrimonio);
            //return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PatrimonioDAO dao = new PatrimonioDAO();
            Patrimonio patrimonio = dao.FindById(id.Value);

            if (patrimonio == null)
            {
                return NotFound();
            }

            return View(patrimonio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            PatrimonioDAO dao = new PatrimonioDAO();
            Patrimonio patrimonio = dao.FindById(id);
            dao.Remove(id);

            return Json(patrimonio);
            //return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PatrimonioDAO dao = new PatrimonioDAO();
            Patrimonio patrimonio = dao.FindById(id.Value);

            if (patrimonio == null)
            {
                return NotFound();
            }

            MarcaDAO marca = new MarcaDAO();
            List<Marca> marcas = marca.FindAll();
            PatrimonioFormViewModel viewModel = new PatrimonioFormViewModel { Patrimonio = patrimonio, Marcas = marcas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PatrimonioFormViewModel patrimonios)
        {
            if (id != patrimonios.Patrimonio.Id)
            {
                return BadRequest();
            }

            PatrimonioDAO dao = new PatrimonioDAO();
            dao.Update(patrimonios.Patrimonio);

            return Json(patrimonios.Patrimonio);
            //return RedirectToAction(nameof(Index));
        }

        public IActionResult Procurar()
        {
            return View();
        }

        public IActionResult SearchJson(PatrimonioFormViewModel patrimonioModel)
        {
            PatrimonioDAO dao = new PatrimonioDAO();
            Patrimonio patrimonio = dao.FindById(patrimonioModel.Patrimonio.Id);

            return Json(patrimonio);
        }
    }
}
