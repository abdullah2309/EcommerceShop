using EcommerceShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceShop.Controllers
{
    public class registerdataController : Controller
    {
        private readonly registerdb dbcontext;

        public registerdataController(registerdb dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data = dbcontext.registers.ToList();
                return View(data);
            }
            return RedirectToAction("login", "adminlogin");
           
        }
        public IActionResult Delete(int id)
        {
            var data = dbcontext.registers.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult CDelete(int id)
        {
            var data = dbcontext.registers.Find(id);
            dbcontext.registers.Remove(data);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
