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
    public class formationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public formationsController(ApplicationDbContext context, UserManager<IdentityUser> usermanage, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _usermanager = usermanage;
            _webHostEnvironment = hostEnvironment;
        }

        // GET: formations
        //public async Task<IActionResult> Index1()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        await DataClient();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //    return View();
            
        //}

        [HttpPost]
        public ActionResult Index(string? format,string? categ,string? it, string? learn,string? test)
        {

            ViewBag.formationRecents = _context.formations.Include(i => i.Student).Include(c => c.categorie).OrderBy(d => d.Date).Take(3).ToList();
            ViewBag.formCount = _context.formations.Count();
            
            if(format != null)
            {
                var forma = _context.formations
                .Include(s => s.Student)
                .Include(rt => rt.categorie).Include(s => s.Student)
                .Where(t => t.Name.Contains(format) || t.categorie.Name == categ).ToList();
                return View(forma);

            }
            else if(categ != null){
                var forma = _context.formations
                .Include(s => s.Student)
                .Include(rt => rt.categorie).Include(s => s.Student).ToList();
                return View(forma);
            }
            else if (it != null)
            {
                var forma = _context.formations
                .Include(s => s.Student)
                .Include(rt => rt.categorie).Include(s => s.Student)
                .Where(t => t.categorie.Name == it).ToList();
                return View(forma);
            }
            else if (learn != null)
            {
                var forma = _context.formations
                .Include(s => s.Student)
                .Include(rt => rt.categorie).Include(s => s.Student)
                .Where(t => t.categorie.Name == it).ToList();
                return View(forma);
            }
            else if (test != null)
            {
                var forma = _context.formations
                .Include(s => s.Student)
                .Include(rt => rt.categorie).Include(s => s.Student)
                .Where(t => t.categorie.Name == it).ToList();
                return View(forma);
            }
            return View();
            

        }


        public async Task<IActionResult> Confirm(int id)
        {
            var form = _context.formations.Find(id);
            if (form.Status != "valider")
            {
                
                form.Status = "valider";
                _context.Update(form);
                await _context.SaveChangesAsync();
                
            }
            
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Refuser(int id)
        {
            var form = _context.formations.Find(id);
            if (form.Status != "refuser")
            {

                form.Status = "refuser";
                _context.Update(form);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction("index");
        }

        //[HttpPost]
        //public ActionResult Index(string? categ)
        //{
        //    ViewBag.formationRecents = _context.formations.Include(i => i.Student).Include(c => c.categorie).OrderBy(d => d.Date).ToList();
        //    ViewBag.formCount = _context.formations.Count();
        //    var forma = _context.formations
        //        .Include(s => s.Student)
        //        .Include(rt => rt.categorie).Include(s => s.Student)
        //        .Where(t => t.categorie.Name == categ).ToList();
        //    ;
        //    return RedirectToAction("Index",forma);
        //}


        public async Task<IActionResult> Index()
        {
            var student = await _usermanager.GetUserAsync(HttpContext.User);
            ViewBag.formCount = _context.formations.Count();
            ViewBag.formationRecents = _context.formations.Include(i => i.Student).Include(c => c.categorie).OrderBy(d => d.Date).Take(2).ToList();
            var format = await _context.formations.Include(i => i.Student).Include(c => c.categorie).ToListAsync();
            return View(format);
        }

        public async Task<IActionResult> Tout()
        {
            var student = await _usermanager.GetUserAsync(HttpContext.User);
            ViewBag.formCount = _context.formations.Count();
            ViewBag.formationRecents = _context.formations.Include(i => i.Student).Include(c => c.categorie).OrderBy(d => d.Date).Take(2).ToList();
            var format = await _context.formations.Include(i => i.Student).Include(c => c.categorie).ToListAsync();
            return RedirectToAction("Index",format);
        }

        public async Task<IActionResult> admin()
        {
            var student = await _usermanager.GetUserAsync(HttpContext.User);
            var format = await _context.formations.Include(i => i.Student).Include(c => c.categorie).Where(s=>s.StudentId == student.Id).ToListAsync();
            ViewBag.formationRecents = _context.formations.Include(i => i.Student).Include(c => c.categorie).OrderBy(d => d.Date).Take(1).ToList();
            return View("admin/index", format);
        }

        public async Task<IActionResult> DataClient()
        {
            var student = await _usermanager.GetUserAsync(HttpContext.User);
            var format = await _context.formations.Include(i => i.Student).Include(c=>c.categorie).ToListAsync();
            return View(format.Where(i=>i.StudentId==student.Id));
        }

        public IActionResult Create()
        {
            ViewBag.categorie = _context.categories.ToList();
            return View();
        }

        public IActionResult Createe()
        {
            ViewBag.categorie = _context.categories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FormationViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                var student = await _usermanager.GetUserAsync(HttpContext.User);
                
                var formation = new formation();
                formation.Date = model.Date;
                formation.Name = model.Name.ToLower();
                formation.Description = model.Description;
                formation.StudentId = student.Id;
                formation.CategorieId = model.CategorieId;
                formation.ProfilePicture = uniqueFileName;

                _context.Add(formation);

                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }

            return View(model);
        }

        private string ProcessUploadedFile(FormationViewModel model)
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

        public void Del_file(int id, FormationViewModel model)
        {
            try
            {
                if(model.SpeakerPicture.FileName != null)
                {
                    var filename = model.SpeakerPicture.FileName;
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, FileLocation.FileUploadFolder);
                    string filePath = Path.Combine(uploadsFolder, filename);
                    System.IO.File.Delete(filePath);
                }
                
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

            var formations = _context.formations.Find(id);
            var formation = new FormationViewModel()
            {
                Id = formations.Id,
                Name = formations.Name,
                Date = formations.Date,
                Description = formations.Description,
                ExistingImage = formations.ProfilePicture
            };
            if (formation == null) return NotFound();

            return View(formation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FormationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = await _usermanager.GetUserAsync(HttpContext.User);
                var formation = _context.formations.Find(model.Id);
                formation.StudentId = student.Id;
                formation.Name = model.Name.ToLower();
                formation.Description = model.Description;
                formation.Date = model.Date;
               

                if (formation.ProfilePicture != null)
                    Del_file(model.Id, model);

                if (model.SpeakerPicture != null)
                {
                    try
                    {
                        var oldfile = _context.formations.Find(model.Id).ProfilePicture;
                        var newfile = model.SpeakerPicture;
                        string uploads = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");

                        formation.ProfilePicture = ProcessUploadedFile(model);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    
                }

                _context.Update(formation);
               await _context.SaveChangesAsync();
                return  View("admin/index");
            }
            return View();
        }

        public IActionResult Detail(int id)
        {
            
            var form = _context.formations.Include(s=>s.Student).Include(s=>s.categorie).FirstOrDefault(r=>r.Id==id);
            ViewBag.categ = _context.titres.Where(r => r.formationId == form.Id);
            ViewBag.Length = _context.titres.Where(r => r.formationId == form.Id).Count();
            return View(form);
        }

        // GET: EtudiantsController/Delete/5
        public ActionResult Delete(int id, FormationViewModel model)
        {
            var formation = _context.formations.FirstOrDefault(a => a.Id == id);
            var form = new FormationViewModel()
            {
                Id = formation.Id,
                Name = formation.Name,
                ExistingImage = formation.ProfilePicture
            };
            if (formation == null)
            {
                return NotFound();
            }
            return View(form);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formation = await _context.formations.FindAsync(id);
            string path = Directory.GetCurrentDirectory();
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), FileLocation.DeleteFileFromFolder, formation.ProfilePicture);
            _context.formations.Remove(formation);
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
