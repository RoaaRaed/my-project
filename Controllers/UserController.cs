using Microsoft.AspNetCore.Mvc;
using my_resturant.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;//new

namespace my_resturant.Controllers
{
    public class UserController : Controller
    {
        private readonly resturantDbContext _context;

        public UserController(resturantDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            var otheruser = _context.Users.FirstOrDefault( u=>u.username==user.username);

            if (otheruser!=null)
            {
                ViewBag.Message = "this user is exist";
              return View();
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("SignIn");
        }
        public IActionResult SignUp()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null)
            {
                return RedirectToAction("Profile");
            }
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.username == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Profile");
            }
            return View();
        }
        public IActionResult SignIn()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null)
            {
                return RedirectToAction("Profile");
            }

            return View();
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }


       
        public IActionResult ChangePassword()
        {
            return View();
        }
        public IActionResult Profile()
        {

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("SignIn");
            }

            var user = _context.Users.Find(userId);
            var menulist = _context.Menulist.ToList();
            var orders = _context.Orders.Where(o=>o.UserId == userId).ToList();
            var userManulist = new UserMenulistViewModel
            {
                User = user,
                Menulist = menulist,
                Order = orders
            };
            return View(userManulist);
        }


        [HttpPost]
        public IActionResult ChangePassword(string currentPassword, string newPassword)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("SignIn");
            }

            var user = _context.Users.Find(userId);
            if (user == null || user.Password != currentPassword)
            {
                ModelState.AddModelError("", "Current password is incorrect");
                return View();
            }

            user.Password = newPassword;
            _context.Update(user);
            _context.SaveChanges();

            return RedirectToAction("Profile");
        }

        [HttpPost]
        public IActionResult AddToOrder(int UserId, int MenulistId)
        {
            var user = _context.Users.Find(UserId);
            var menuItem = _context.Menulist.Find(MenulistId);
            var order = new Order
            {
                UserId = UserId,
                User = user,
                MenulistId = MenulistId,
                Menulist = menuItem
            };

            _context.Orders.Add(order);
            _context.SaveChanges();


            return RedirectToAction("Profile");
        }

        
        public IActionResult RemoveFromOrder(int Id) 
        {
            var order = _context.Orders.Find(Id);
            _context.Orders.Remove(order);

            _context.SaveChanges();

            return RedirectToAction("Profile");
        
        
        }

    }
}
