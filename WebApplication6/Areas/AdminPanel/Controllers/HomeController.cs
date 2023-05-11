using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Areas.AdminPanel.Controllers
{
  
        [Area("AdminPanel")]
        public class HomeController : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
        }

    
}
