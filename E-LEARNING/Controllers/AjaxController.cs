using E_LEARNING.Data;
using E_LEARNING.Models;
using E_LEARNING.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.Controllers
{
    public class AjaxController : Controller
    {

        private readonly ApplicationDbContext _context;

        public IWebHostEnvironment _webHostEnvironment { get; set; }

        public AjaxController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }

        // GET: AjaxController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult modal()
        {
            return View();
        }

        public ActionResult GetData()
        {
            var categ = _context.categories.ToList();
            return Json(new { data = categ });
        }

        // GET: AjaxController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AjaxController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AjaxController/Create
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CategoriesViewModel model)
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

        public string ProcessUploadedFile(CategoriesViewModel model)
        {
            string uniqueFileName = null;

            if (model.SpeakerPicture != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, FileLocation.FileUploadFolder);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.SpeakerPicture;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.SpeakerPicture.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        // GET: AjaxController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AjaxController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AjaxController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AjaxController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
