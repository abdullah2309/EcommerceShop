using EcommerceShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceShop.Controllers
{
    public class adminloginController : Controller
    {
        private readonly registerdb dbcontext;

        public adminloginController(registerdb dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(adminlogin login)
        {
            var data = dbcontext.adminlogins.Where(a => a.Email == login.Email && a.password == login.password).FirstOrDefault();
            if (data != null)
            {
                HttpContext.Session.SetString("adminlogin", data.Email);
                return RedirectToAction("Index", "administrator");

            }
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                HttpContext.Session.Remove("adminlogin");
                return RedirectToAction("Login");
            }
            return RedirectToAction("Login");
        }
    
    public IActionResult show()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data = dbcontext.adminlogins.ToList();
                return View(data);
            }
            return RedirectToAction("login", "adminlogin");

        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data = dbcontext.adminlogins.Find(id);
                return View(data);
            }
            return RedirectToAction("login", "adminlogin");

           
        }
        [HttpPost]
        public IActionResult Edit(int id , adminlogin login)
        {
            var data = dbcontext.adminlogins.Find(id);
            data.Email = login.Email;
            data.password = login.password;
            dbcontext.SaveChanges();
            return RedirectToAction("Index", "administrator");
        }
    }
}
