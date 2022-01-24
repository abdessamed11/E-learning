using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_LEARNING.Data;
using E_LEARNING.Models;
using E_LEARNING.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace E_LEARNING.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IWebHostEnvironment _webHostEnvironment { get; set; }

        public CategoriesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.categories.ToListAsync());
        }
        public async Task<IActionResult> Index1()
        {
            return View(await _context.categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // GET: EtudiantsController/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: EtudiantsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriesViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Categorie categorie = new Categorie
                {
                    Name = model.Name,
                    ProfilePicture = uniqueFileName
                };
                _context.Add(categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var categorie = _context.categories.Find(id);

            var categories = new CategoriesViewModel()
            {
                Id = categorie.Id,
                Name = categorie.Name,
                ExistingImage = categorie.ProfilePicture
           
                
            };
            if (categorie == null) return NotFound();

            return View(categories);
        }

        public void Del_file(int id, CategoriesViewModel model)
        {
            var filename = _context.categories.Find(model.Id).ProfilePicture;
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, FileLocation.FileUploadFolder);
            string filePath = Path.Combine(uploadsFolder, filename);
            System.IO.File.Delete(filePath);


        }

        public string ProcessUploadedFile(CategoriesViewModel model)
        {
            string uniqueFileName = null;

            if (model.SpeakerPicture != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, FileLocation.FileUploadFolder);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.SpeakerPicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.SpeakerPicture.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        //POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var etudiant = await _context.categories.FindAsync(model.Id);
                etudiant.Id = model.Id;
                etudiant.Name = model.Name;
                
                if(model.SpeakerPicture != null)
                {
                    if (etudiant.ProfilePicture != null)
                        Del_file(id, model);
                    var oldfile = _context.categories.Find(model.Id).ProfilePicture;
                    var newfile = model.SpeakerPicture;
                    string uploads = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");

                    etudiant.ProfilePicture = ProcessUploadedFile(model);
                }
                

                _context.Update(etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: EtudiantsController/Delete/5
        public ActionResult Delete(int id, CategoriesViewModel model)
        {
            var etudiant = _context.categories.FirstOrDefault(a => a.Id == id);
            var etud = new CategoriesViewModel()
            {
                Id = etudiant.Id,
                Name = etudiant.Name,
                ExistingImage = etudiant.ProfilePicture
            };
            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etud);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Etudiant = await _context.categories.FindAsync(id);
            string path = Directory.GetCurrentDirectory();
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), FileLocation.DeleteFileFromFolder, Etudiant.ProfilePicture);
            _context.categories.Remove(Etudiant);
            if (System.IO.File.Exists(CurrentImage))
            {
                System.IO.File.Delete(CurrentImage);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieExists(int id)
        {
            return _context.categories.Any(e => e.Id == id);
        }
    }
}
