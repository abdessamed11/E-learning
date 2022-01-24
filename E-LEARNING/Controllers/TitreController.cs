using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_LEARNING.Data;
using E_LEARNING.Models;
using Microsoft.AspNetCore.Identity;
using E_LEARNING.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace E_LEARNING.Controllers
{
    public class TitreController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TitreController(ApplicationDbContext context, UserManager<IdentityUser> usermanage, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _usermanager = usermanage;
            _webHostEnvironment = hostEnvironment;
        }

        //GET: formations
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                await Data();
            }
            else
            {
                return NotFound();
            }
            return View();

        }

        

        [HttpPost]
        public async Task<ActionResult> Index(string? categ, string? it)
        {

            //var titre = await _context.titres.Include(s => s.formation).ThenInclude(rt => rt.Student).ToListAsync();
            var student = await _usermanager.GetUserAsync(HttpContext.User);

            if (categ != null || it != null)
            {
                var titre = await _context.titres
                            .Include(s => s.formation)
                            .ThenInclude(rt => rt.Student)
                            .Where(s=>s.formation.Name == categ || s.formation.Name == it)
                            .Where(t=>t.formation.Student.Id == student.Id)
                            .ToListAsync();

                return View(titre);
            
            }else if (categ == null || it == null)
            {
                var titre = await _context.titres
                            .Include(s => s.formation)
                            .ThenInclude(rt => rt.Student)
                            .Where(t => t.formation.Student.Id == student.Id)
                            .ToListAsync();

                return View(titre);
            }
            
            return View();


        }

        public async Task<IActionResult> Data()
        {
            var student = await _usermanager.GetUserAsync(HttpContext.User);
            var titre = await _context.titres.Include(s => s.formation).ThenInclude(rt => rt.Student).ToListAsync();
            return View(titre);
        }

        public async Task<IActionResult> Data(string tous)
        {
            var student = await _usermanager.GetUserAsync(HttpContext.User);
            var titre = await _context.titres.Include(s => s.formation).ThenInclude(rt => rt.Student).Where(s=>s.formation.Name == tous).ToListAsync();
            return View(titre);
        }

        public IActionResult Create()
        {
            ViewBag.formation = _context.formations.ToList();
            return View();
        }
        public IActionResult CreateTitre(int id)
        {
            ViewBag.format = _context.formations.FirstOrDefault(s=>s.Id == id);
            ViewBag.formation = _context.formations.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTitre(TitreViewModel model)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                var student = await _usermanager.GetUserAsync(HttpContext.User);
                

                var titre = new Titre();
                titre.Date = DateTime.Today;
                titre.Name = model.Name.ToLower();
                titre.Article_art = model.Article_art;
                titre.video_art = model.video_art;
                titre.formationId = model.formationId;
                titre.ProfilePicture = uniqueFileName;

                _context.Add(titre);

                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TitreViewModel model)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                var student = await _usermanager.GetUserAsync(HttpContext.User);

                var titre = new Titre();
                titre.Date = model.Date;
                titre.Name = model.Name.ToLower();
                titre.Article_art = model.Article_art;
                titre.video_art = model.video_art;
                titre.formationId = model.formationId;
                titre.ProfilePicture = uniqueFileName;

                _context.Add(titre);

                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }

            return View(model);
        }

        private string ProcessUploadedFile(TitreViewModel model)
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

        public void Del_file(int id, TitreViewModel model)
        {
            try
            {
                var filename = model.SpeakerPicture.FileName;
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, FileLocation.FileUploadFolder);
                string filePath = Path.Combine(uploadsFolder, filename);
                System.IO.File.Delete(filePath);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var titres = _context.titres.Find(id);
            var titre = new TitreViewModel()
            {
                Id = titres.Id,
                Name = titres.Name,
                Date = titres.Date,
                Article_art = titres.Article_art,
                video_art = titres.video_art,
                ExistingImage = titres.ProfilePicture
            };
            if (titre == null) return NotFound();

            return View(titre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TitreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = await _usermanager.GetUserAsync(HttpContext.User);
                var titre = _context.titres.Find(model.Id);

                titre.Name = model.Name.ToLower();
               
                titre.Date = model.Date;


                if (titre.ProfilePicture != null)
                    Del_file(model.Id, model);

                if (model.SpeakerPicture != null)
                {
                    try
                    {
                        var oldfile = _context.titres.Find(model.Id).ProfilePicture;
                        var newfile = model.SpeakerPicture;
                        string uploads = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");

                        titre.ProfilePicture = ProcessUploadedFile(model);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }

                _context.Update(titre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var form = _context.titres.Include(s => s.formation).ThenInclude(s=>s.Student).FirstOrDefault(r => r.Id == id);
            return View(form);
        }

        // GET: EtudiantsController/Delete/5
        public ActionResult Delete(int id, TitreViewModel model)
        {
            var titre = _context.titres.FirstOrDefault(a => a.Id == id);
            var titres = new TitreViewModel()
            {
                Id = titre.Id,
                Name = titre.Name,
                ExistingImage = titre.ProfilePicture
            };
            if (titre == null)
            {
                return NotFound();
            }
            return View(titres);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var titre = await _context.titres.FindAsync(id);
            string path = Directory.GetCurrentDirectory();
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), FileLocation.DeleteFileFromFolder, titre.ProfilePicture);
            _context.titres.Remove(titre);
            if (System.IO.File.Exists(CurrentImage))
            {
                System.IO.File.Delete(CurrentImage);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieExists(int id)
        {
            return _context.formations.Any(e => e.Id == id);
        }

    }
}
