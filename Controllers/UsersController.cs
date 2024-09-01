using Authentication.Data;
using Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplecationDBContex context;
        public UsersController(ApplecationDBContex context) {
            this.context = context;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User u)
        {
            context.users.Add(u);
            context.SaveChanges();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User u)
        {
           var checkUser= context.users.Where(user=>user.UserName==u.UserName && user.Password==u.Password );
if (checkUser.Any())
            {
                return RedirectToAction("Index");
            }
            return View(u);
        }
        public IActionResult Index()
        {
            var user = context.users.Where(u=>u.IsActive==false).ToList();
            foreach(var a  in user)
            {
                Console.WriteLine(a.UserName);
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult ActivateUser(Guid userId)
        {
            var user = context.users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.IsActive = true;
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
