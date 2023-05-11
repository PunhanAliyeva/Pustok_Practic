using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using WebApplication6.DAL;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        public AppDbContext _appDbContext;
        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Book>Books=_appDbContext.Books.ToList();
            List<Category> Categories = _appDbContext.Categories.ToList();
            return View();
        }
      
    }
}