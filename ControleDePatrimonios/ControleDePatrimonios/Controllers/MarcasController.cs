using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ControleDePatrimonios.Models;

namespace ControleDePatrimonios.Controllers
{
    public class MarcasController : Controller
    {
        public IActionResult Index()
        {
            List<Marca> list = new MarcaDAO().FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ListAllJSon()
        {
            List<Marca> list = new MarcaDAO().FindAll();
            return Json(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Marca marca)
        {
            MarcaDAO dao = new MarcaDAO();
            marca = dao.Insert(marca);

            return Json(marca);
            // return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MarcaDAO dao = new MarcaDAO();
            Marca marca = dao.FindById(id.Value);

            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            MarcaDAO dao = new MarcaDAO(); ;
            Marca marca = dao.FindById(id);
            dao.Remove(id);

            return Json(marca);
            // return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MarcaDAO dao = new MarcaDAO();
            Marca viewModel = dao.FindById(id.Value);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Marca marca)
        {
            if (id != marca.MarcaId)
            {
                return BadRequest();
            }

            MarcaDAO dao = new MarcaDAO();
            dao.Update(marca);

            return Json(marca);
            // return RedirectToAction(nameof(Index));
        }

        public IActionResult Procurar()
        {
            return View();
        }

        public IActionResult SearchJson(Marca marca)
        {
            MarcaDAO dao = new MarcaDAO();
            marca = dao.FindById(marca.MarcaId);

            return Json(marca);
        }
    }
}
