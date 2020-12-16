using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectStore.Models;
using ProjectStore.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStore.Controllers
{
    public class CategorieController : Controller
    {
        readonly ICategorieRepository categorierepository;
        public CategorieController(ICategorieRepository categorierepository)
        {
            this.categorierepository = categorierepository;
        }
        // GET: CategorieController
        public ActionResult Index()
        {
            return View(categorierepository.GetAll());
        }

        // GET: CategorieController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.certificationcount = categorierepository.CertificationsCount(id);
            var categorie = categorierepository.GetById(id);
            return View(categorie);
        }

        // GET: CategorieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategorieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorie s)
        {
            try
            {
                categorierepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieController/Edit/5
        public ActionResult Edit(int id)
        {
            var categorie = categorierepository.GetById(id);
            return View(categorie);
        }

        // POST: CategorieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categorie s)
        {
            try
            {
                categorierepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieController/Delete/5
        public ActionResult Delete(int id)
        {
            var categorie = categorierepository.GetById(id);
            return View(categorie);
        }

        // POST: CategorieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categorie s)
        {
            try
            {
                categorierepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
