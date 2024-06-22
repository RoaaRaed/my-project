using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_resturant.Models;
using System.Diagnostics;

namespace my_resturant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly resturantDbContext _context;

        public HomeController(ILogger<HomeController> logger, resturantDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var menulist = _context.Menulist.ToList();
            return View(menulist);

        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
