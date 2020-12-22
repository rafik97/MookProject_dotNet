using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectStore.Models;
using ProjectStore.Models.Repositories;
using ProjectStore.ViewModel;
using System;
using System.IO;

namespace ProjectStore.Controllers
{
    public class CertificationController : Controller
    {
        readonly ICertificationRepository certificationRepository;
        readonly ICategorieRepository categorieRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public CertificationController(ICertificationRepository certificationRepository, ICategorieRepository categorieRepository, IWebHostEnvironment hostingEnvironment)
        {
            this.certificationRepository = certificationRepository;
            this.categorieRepository = categorieRepository;
            this.hostingEnvironment = hostingEnvironment;
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
            ViewBag.CategorieID = new SelectList(categorieRepository.GetAll(), "CategorieId", "CategorieName");
            var certification = certificationRepository.GetById(id);
            return View(certification);
        }

        // GET: CertificationController/Create
        public ActionResult Create()
        {
            ViewBag.CategorieID = new SelectList(categorieRepository.GetAll(), "CategorieId", "CategorieName");
            return View();
        }

        // POST: CertificationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            ViewBag.CategorieID = new SelectList(categorieRepository.GetAll(), "CategorieId", "CategorieName");
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.Photo != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                    // To make sure the file name is unique we are appending a new
                    // GUID value and an underscore to the file name

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder

                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Certification newCertification = new Certification
                {
                    CertificationName = model.CertificationName,
                    Description = model.Description,
                    Price = model.Price,
                    CategorieId = model.CategorieId,
                    Categorie = model.Categorie,
                    // Store the file name in PhotoPath property of the certification object
                    // which gets saved to the Certifications database table
                    PhotoPath = uniqueFileName
                };

                certificationRepository.Add(newCertification);
                return RedirectToAction("details", new { id = newCertification.CertificationId });
            }

            return View();
        }

        // GET: CertificationController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategorieID = new SelectList(categorieRepository.GetAll(), "CategorieId", "CategorieName");
            Certification certification = certificationRepository.GetById(id);
            EditViewModel editViewModel = new EditViewModel
            {
                CertificationId = certification.CertificationId,
                CertificationName = certification.CertificationName,
                Description = certification.Description,
                Price = certification.Price,
                CategorieId = certification.CategorieId,
                Categorie = certification.Categorie,
                ExistingPhotoPath = certification.PhotoPath
            };
            return View(editViewModel);
        }

        // POST: CertificationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel model)
        {
            
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the certification being edited from the database
                Certification certification = certificationRepository.GetById(model.CertificationId);
                // Update the certification object with the data in the model object
                certification.CertificationName = model.CertificationName;
                certification.Description = model.Description;
                certification.Price = model.Price;
                certification.CategorieId = model.CategorieId;
                certification.Categorie = model.Categorie;

                // If the user wants to change the photo, a new photo will be
                // uploaded and the Photo property on the model object receives
                // the uploaded photo. If the Photo property is null, user did
                // not upload a new photo and keeps his existing photo
                if (model.Photo != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    // Save the new photo in wwwroot/images folder and update
                    // PhotoPath property of the certification object which will be
                    // eventually saved in the database
                    certification.PhotoPath = ProcessUploadedFile(model);
                }

                // Call update method on the repository service passing it the
                // certification object to update the data in the database table
                Certification updatedCertification = certificationRepository.Edit(certification);
                if (updatedCertification != null)
                    return RedirectToAction("index");
                else
                    return NotFound();
            }

            return View(model);
        }

        [NonAction]
        private string ProcessUploadedFile(EditViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
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
