using Microsoft.AspNetCore.Mvc;
using my_resturant.Models;
using System.Linq;

namespace my_resturant.Controllers
{
    public class MenulistController : Controller
    {
        private readonly resturantDbContext _context;

        public MenulistController(resturantDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null || userId != 1)
            {
                return RedirectToAction("ForAdminMessage");
            }
            var menulist = _context.Menulist.ToList();
            return View(menulist);
        }
        public IActionResult Create()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null || userId != 1)
            {
                return RedirectToAction("ForAdminMessage");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Menulist menulist)
        {
            _context.Menulist.Add(menulist);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public IActionResult Edit(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null || userId != 1)
            {
                return RedirectToAction("ForAdminMessage");
            }

            var menulist = _context.Menulist.Find(id);

            if (menulist == null)
            {
                return NotFound();
            }
            return View(menulist);
        }

        [HttpPost]
        public IActionResult Edit(Menulist menulist)
        {
            _context.Menulist.Update(menulist);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var menulist = _context.Menulist.Find(id);

            if (menulist == null)
            {
                return NotFound();
            }
            _context.Menulist.Remove(menulist);
            _context.SaveChanges(); 
            return RedirectToAction("Index");
        }


        public IActionResult ForAdminMessage()
        {
            return View();
        }

       
    }
}
