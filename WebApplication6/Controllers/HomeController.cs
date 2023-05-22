using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using WebApplication6.DAL;
using WebApplication6.Models;
using WebApplication6.ViewModels;

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
            List<Book> Books = _appDbContext.Books.ToList();
            List<Category> Categories = _appDbContext.Categories.ToList();
            return View();
        }



        //public async Task<IActionResult> AddBasket(int? id)
        //{
        //    if (id == null || id < 1) return BadRequest();
        //    Product product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.ID == id);
        //    if (product == null) return NotFound();
        //    List<BasketCookiesItem> basket;
        //    if (Request.Cookies["Basket"] == null)
        //    {
        //        basket = new List<BasketCookiesItem>();
        //        basket.Add(new BasketCookiesItem
        //        {
        //            ID = product.ID,
        //            Count = 1
        //        });

        //    }
        //    else
        //    {

        //    }
        //}


    }
}
