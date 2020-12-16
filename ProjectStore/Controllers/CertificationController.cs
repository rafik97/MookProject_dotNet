using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectStore.Models;
using ProjectStore.Models.Repositories;

namespace ProjectStore.Controllers
{
    public class CertificationController : Controller
    {
        readonly ICertificationRepository certificationRepository;
        readonly ICategorieRepository categorieRepository;

        public CertificationController(ICertificationRepository certificationRepository, ICategorieRepository categorieRepository)
        {
            this.certificationRepository = certificationRepository;
            this.categorieRepository = categorieRepository;
        }

        // GET: CertificationController
        public ActionResult Index()
        {
            ViewBag.CategorieID = new SelectList(categorieRepository.GetAll(), "CategorielID", "CategorieName");
            return View(certificationRepository.GetAll());
        }

        // GET: CertificationController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.SchoolID = new SelectList(categorieRepository.GetAll(), "CategorieId", "CategorieName");
            return View();
        }

        // GET: CertificationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CertificationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Certification c)
        {
            try
            {
                ViewBag.CategorieId = new SelectList(categorieRepository.GetAll(), "CategorieId", "CategorieName", c.CategorieId);
                certificationRepository.Add(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CertificationController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategorieId = new SelectList(categorieRepository.GetAll(), "CategorieId", "CategorieName");
            return View(certificationRepository.GetById(id));
        }

        // POST: CertificationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Certification c)
        {
            try
            {
                ViewBag.CategorieId = new SelectList(categorieRepository.GetAll(), "CategorieId", "CategorieName", c.CategorieId);
                certificationRepository.Edit(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CertificationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(certificationRepository.GetById(id));
        }

        // POST: CertificationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Certification c)
        {
            try
            {
                certificationRepository.Delete(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
