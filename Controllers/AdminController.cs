﻿using ProjetC_MVCSalleSport.Models;
using System.Linq;
using System.Web.Mvc;

namespace ProjetC_MVCSalleSport.Controllers
{
    public class AdminController : Controller
    {
        private readonly ContexteDeBaseDeDonnees _context;
        public AdminController()
        {
            _context = new ContexteDeBaseDeDonnees();
        }

        [HttpGet]
        public ActionResult ListeCours()
        {
            var cours = _context.Cours.ToList();
            return View("ListeCours", cours);
        }


        [HttpGet]
        public ActionResult Ajouter()
        {
            return View("AjouterCours");
        }


        [HttpPost]
        public ActionResult AjouterCours(Cours cours)
        {


            if (ModelState.IsValid)
            {
                _context.Cours.Add(cours);
                _context.SaveChanges();
                return RedirectToAction("ListeCours");
            }
            return View(cours);
        }
    }
}