using EcommerceShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceShop.Controllers
{
    public class registerloginController : Controller
    {
        private readonly registerdb dbcontext;

        public registerloginController( registerdb dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public IActionResult register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult register(register register)
        {
            if (ModelState.IsValid)
            {
                dbcontext.registers.Add(register);
                dbcontext.SaveChanges();
                TempData["submitted"] = "Your data has been submitted. Your are Login in wibsite";
                return View();

            }
            return View();

        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(register register)
        {
            var data = dbcontext.registers.Where(a => a.Email == register.Email && a.Password == register.Password).FirstOrDefault();
            if(data != null)
            {
                HttpContext.Session.SetString("LoginSession", data.Email );
                return RedirectToAction("profile", "Home");
                
            }
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("LoginSession") != null)
            {
                HttpContext.Session.Remove("LoginSession");
                return RedirectToAction("login");
            }
            return View();
        }
    }
}
