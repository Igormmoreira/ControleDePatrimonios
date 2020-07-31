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
            List<Marca> list = new MarcaDAO().Listar();

            return View(list);
            // return Json(marca); // resultado em JSON
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ListAllJSon()
        {
            List<Marca> list = new MarcaDAO().Listar();
            return Json(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Marca marca)
        {
            MarcaDAO marcaDAO = new MarcaDAO();
            marcaDAO.Insert(marca);

            return RedirectToAction(nameof(Index));
        }
    }
}
