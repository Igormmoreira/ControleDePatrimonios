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
            List<Marca> list = new MarcaDAO().FindAll();

            return View(list);
            // return Json(marca); // resultado em JSON
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
            dao.Insert(marca);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {

            // Verificar se o int é válido

            // MarcaDAO dao = new MarcaDAO();
            // Marca marca = dao.FindById(id);

            // Verificar se a marca não é nulo;

            // Apagar a instanciação abaixo;
            Marca marca = new Marca { MarcaId = 1, Nome = "Marca teste 1" };
            return View(marca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            MarcaDAO dao = new MarcaDAO(); ;
            dao.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
