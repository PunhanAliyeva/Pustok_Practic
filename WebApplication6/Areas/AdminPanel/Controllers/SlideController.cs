using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.DAL;
using WebApplication6.Models;

namespace WebApplication6.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SlideController:Controller
    {
        public AppDbContext _appDbContext;
        public SlideController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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
            FileStream file=new FileStream(@"C:\Users\ClassTime\Desktop\WebApp\WebApplication6\wwwroot\admin\images\"+slide.Photo.FileName,FileMode.Create);
            await slide.Photo.CopyToAsync(file);
            slide.Image = slide.Photo.FileName;
            await _appDbContext.Slides.AddAsync(slide);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }

    }
}
