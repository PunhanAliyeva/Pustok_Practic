using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using WebApplication6.DAL;
using WebApplication6.Models;

namespace WebApplication6.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SlideController:Controller
    {
        public AppDbContext _appDbContext;
        public IWebHostEnvironment _env;
        public SlideController(AppDbContext appDbContext,IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Slide> slides = await _appDbContext.Slides.ToListAsync();

            return View(slides);
        }
         
        public async Task<IActionResult> Create(Slide slide)
        {
            if (slide.Photo == null)
            {
                ModelState.AddModelError("Photo", "Sekil hissesi bos ola bilmez");
                return View();
            }
            if (!slide.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Gonderilen faylin tipi uygun deyil");
                return View();
            }
            if (slide.Photo.Length > 200 * 1024)
            {
                ModelState.AddModelError("Photo", "Gonderilen faylin hecmi 200 kb-dan boyuk olmamalidir");
                return View();
            }
            string fileName = Guid.NewGuid().ToString() + slide.Photo.FileName;
            string fullPath = Path.Combine(_env.WebRootPath, @"admin\images\BookImages",fileName);
            using (FileStream file = new FileStream(fullPath, FileMode.Create))
            {
                await slide.Photo.CopyToAsync(file);
            }

            slide.Image = slide.Photo.FileName;
            await _appDbContext.Slides.AddAsync(slide);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
            return Content(Guid.NewGuid().ToString());  
        }





        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Slide slide = await _appDbContext.Slides.FirstOrDefaultAsync(s => s.ID == id);
            if (slide == null)
            {
                return NotFound();
            } 
            return View(slide);
        }





        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null || id < 1)
            {
                return BadRequest();
            }
            Slide slide = await _appDbContext.Slides.FirstOrDefaultAsync(s => s.ID == id);
            if (slide == null)
            {
                return NotFound();
            }
            string path = Path.Combine(_env.WebRootPath, @"admin/images/BookImages");
            if(System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _appDbContext.Remove(slide);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }

}
