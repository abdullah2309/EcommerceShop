using EcommerceShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceShop.Controllers
{
    public class administratorController : Controller
    {
        private readonly MyDbcontext dbcontext;
        private readonly registerdb registerdb;

        public administratorController(MyDbcontext dbcontext , registerdb registerdb) 
        {
            this.dbcontext = dbcontext;
            this.registerdb = registerdb;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                return View();
            }
            return RedirectToAction("login", "adminlogin");

        }
        public IActionResult showfeedback()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data = dbcontext.feedbacks.ToList();
                return View(data);
            }
            return RedirectToAction("login", "adminlogin");

        }
        public IActionResult addcategory()
        {

            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                ViewData["addCategories"] = dbcontext.addCategories;
                return View();
            }
            return RedirectToAction("login", "adminlogin");

            
        }
        [HttpPost]
        public IActionResult addcategory(AddCategory addcategory)
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                if (ModelState.IsValid)
                {
                    dbcontext.addCategories.Add(addcategory);
                    dbcontext.SaveChanges();
                    return RedirectToAction("addcategory");
                }
                return RedirectToAction("addcategory");
            }
            return RedirectToAction("login", "adminlogin");
         

        }
        public IActionResult showcategory()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data = dbcontext.addCategories.ToList();
                return View(data);
            }
            return RedirectToAction("login", "adminlogin");
           
        }

        public IActionResult Delete(int id)
        {
            var data = dbcontext.addCategories.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult CDelete(int id)
        {
            var data = dbcontext.addCategories.Find(id);
            dbcontext.addCategories.Remove(data);
            dbcontext.SaveChanges();
            return RedirectToAction("addcategory");
        }
        public IActionResult Edit(int id)
        {
            var data = dbcontext.addCategories.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(int id , AddCategory category)
        {
            var Data = dbcontext.addCategories.Find(id);
            Data.category_name = category.category_name;
            dbcontext.SaveChanges();
            return RedirectToAction("addcategory");

        }
        public IActionResult Order()
        {
          
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data =   registerdb.buynow.ToList();
            return View(data);
            }
            return RedirectToAction("login", "adminlogin");
        }
    }
}
