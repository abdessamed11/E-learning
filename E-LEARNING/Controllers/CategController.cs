using E_LEARNING.Models;
using E_LEARNING.Repo;
using E_LEARNING.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.Controllers
{
    public class CategController : Controller
    {
        private readonly IRepoCategorie repoCat;
        private readonly IWebHostEnvironment hostEnvironment;

        public CategController(IRepoCategorie repoCat, IWebHostEnvironment hostEnvironment)
        {
            this.repoCat = repoCat;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            var categ = repoCat.GetAll();
            return View(categ);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriesViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Categorie categorie = new Categorie
                {
                    Name = model.Name,
                    ProfilePicture = uniqueFileName
                };
                 repoCat.Create(categorie);
                
                return RedirectToAction(nameof(Index));
               
            }
            return View(model);

        }

        public string ProcessUploadedFile(CategoriesViewModel model)
        {
            string uniqueFileName = null;

            if (model.SpeakerPicture != null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, FileCateg.FileUploadFolder);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.SpeakerPicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.SpeakerPicture.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        public ActionResult Delete(int id, CategoriesViewModel model)
        {
            var categ = repoCat.GetByid(id);
            var categg = new CategoriesViewModel()
            {
                Id = categ.Id,
                Name = categ.Name,
                ExistingImage = categ.ProfilePicture
            };
            if (categ == null)
            {
                return NotFound();
            }
            return View(categg);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            
            var categorie = repoCat.GetByid(id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var categorie = repoCat.GetByid(id);
            string path = Directory.GetCurrentDirectory();
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), FileCateg.DeleteFileFromFolder, categorie.ProfilePicture);
            repoCat.Delete(categorie);
            if (System.IO.File.Exists(CurrentImage))
            {
                System.IO.File.Delete(CurrentImage);
            }
            
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {

            var categorie = repoCat.GetByid(id);

            var categories = new CategoriesViewModel()
            {
                Id = categorie.Id,
                Name = categorie.Name,
                ExistingImage = categorie.ProfilePicture

            };
            if (categorie == null) return NotFound();

            return View(categories);
        }

        //POST: Categ/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var categorie = repoCat.GetByid(id);
                categorie.Id = model.Id;
                categorie.Name = model.Name;

                if (model.SpeakerPicture != null)
                {
                    if (categorie.ProfilePicture != null)
                        Del_file(id, model);
                    var oldfile = repoCat.GetByid(id).ProfilePicture;
                    var newfile = model.SpeakerPicture;
                    string uploads = Path.Combine(hostEnvironment.WebRootPath, "Uploads");

                    categorie.ProfilePicture = ProcessUploadedFile(model);
                }


                repoCat.Update(categorie);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public void Del_file(int id, CategoriesViewModel model)
        {
            var filename = repoCat.GetByid(id).ProfilePicture;
            string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, FileCateg.FileUploadFolder);
            string filePath = Path.Combine(uploadsFolder, filename);
            System.IO.File.Delete(filePath);


        }
    }
}
