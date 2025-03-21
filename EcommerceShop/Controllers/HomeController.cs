using EcommerceShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EcommerceShop.Migrations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace EcommerceShop.Controllers
{
    public class HomeController : Controller
	{
        private readonly MyDbcontext dbcontext;
        private readonly registerdb registerdb;
        private readonly IHttpContextAccessor httpContextAccessor;

        public HomeController(MyDbcontext dbcontext , registerdb registerdb , IHttpContextAccessor httpContextAccessor )
        {
            this.dbcontext = dbcontext;
            this.registerdb = registerdb;
            this.httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            ViewData["cart"] = dbcontext.addProducts;
            ViewData["salecart"] = dbcontext.addProductsales;
            return View();
        }
        public IActionResult profile()
        {
            if (HttpContext.Session.GetString("LoginSession") != null)
            {
                var email = httpContextAccessor.HttpContext.Session.GetString("LoginSession");
                var cartData = registerdb.registers.Where(i=>i.Email == email).ToList();
                return View(cartData);
            }
                return RedirectToAction("Index");
        }
        public IActionResult proedit(int id)
        {
            var data = registerdb.registers.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult proedit(int id , register register)
        {
            var data = registerdb.registers.Find(id);
            if (ModelState.IsValid)
            {
                data.Name = register.Name;
                data.Email = register.Email;
                data.Address = register.Address;
                data.PhoneNumber = register.PhoneNumber;
                data.Password = register.Password;
                registerdb.SaveChanges();
                return RedirectToAction("profile");
            }
            
                return RedirectToAction("proedit");

        }
        public IActionResult shop()
        {
            ViewData["cart"] = dbcontext.addProducts;
            return View();
        }
        public IActionResult shopcart()
        {
            var data = dbcontext.addProducts.ToList();
            return View(data);
        }
        public IActionResult salecart()
        {
            var data = dbcontext.addProducts.ToList();
            return View(data);
        }
        public IActionResult blog()
        {
            return View();
        }
        public IActionResult about()
        {
            return View();
        }
        public IActionResult feedback()
        {
            return View();
        }
        [HttpPost]
        public IActionResult feedback(Models.feedback feed)
        {
            dbcontext.feedbacks.Add(feed);
            dbcontext.SaveChanges();
            TempData["feedback"] = "Your Feedback has been submitted.";
            return View();
        }

        public IActionResult addcart(int id)
        {
            if (HttpContext.Session.GetString("LoginSession") != null)
            {

                var useremail = httpContextAccessor.HttpContext.Session.GetString("LoginSession");



                var product = dbcontext.addProducts.Where(t => t.Product_id == id).FirstOrDefault();

                if (product != null)
                {
                    var cartItem = new Addtocart
                    {
                        Product_Name = product.Product_Name,
                        Product_Price = product.Product_Price,
                        Product_Details = product.Product_Details,
                        Product_Images = product.Product_Images,
                        Quantity = "1",
                        UserEmail = useremail
                    };
                    registerdb.Addtocart.Add(cartItem);
                    registerdb.SaveChanges();
                    return RedirectToAction("Cart");
                }
                else
                {
                    TempData["cart"] = "Don't have an account? Create one.";
                    return RedirectToAction("login", "registerlogin");
                }
            }
            TempData["cart"] = "Don't have an account? Create one.";
            return RedirectToAction("login", "registerlogin");
        }
        public IActionResult saleaddcart(int id)
        {
            if (HttpContext.Session.GetString("LoginSession") != null)
            {

                var useremail = httpContextAccessor.HttpContext.Session.GetString("LoginSession");



                var product = dbcontext.addProductsales.Where(t => t.Product_id == id).FirstOrDefault();

                if (product != null)
                {
                    var cartItem = new Addtocart
                    {
                        Product_Name = product.Product_Name,
                        Product_Price = product.Product_Price,
                        Product_Details = product.Product_Details,
                        Product_Images = product.Product_Images,
                        Quantity = "1",
                        UserEmail = useremail
                    };
                    registerdb.Addtocart.Add(cartItem);
                    registerdb.SaveChanges();
                    return RedirectToAction("Cart");
                }
                else
                {
                    TempData["cart"] = "Don't have an account? Create one.";
                    return RedirectToAction("login", "registerlogin");
                }
            }
            TempData["cart"] = "Don't have an account? Create one.";
            return RedirectToAction("login", "registerlogin");
        }
        public IActionResult Cart(int id)
        {
            if (HttpContext.Session.GetString("LoginSession") != null)
            {
                var useremailtow = httpContextAccessor.HttpContext.Session.GetString("LoginSession");
                var cartData = registerdb.Addtocart.Where(t => t.UserEmail == useremailtow).ToList();
               
                    return View(cartData);
            
            }
            TempData["cart"] = "Don't have an account? Create one.";
            return RedirectToAction("login" , "registerlogin");
        }
        public ActionResult CartDetele(int id)
        {
            var data = registerdb.Addtocart.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult ConfirmCartDetele(int id)
        {
            var data = registerdb.Addtocart.Find(id);
            registerdb.Remove(data);
            registerdb.SaveChanges();
            return RedirectToAction("Cart");
        }

        public IActionResult Order(string Product_Name)
        {
            var data = registerdb.Addtocart.Where(g => g.Product_Name == Product_Name).FirstOrDefault();

            if (data == null)
            {
                return NotFound(); 
            }

            var orderForm = new buynow
            {
                Product_Name = data.Product_Name,
            };

            return View(orderForm); 
        }

        [HttpPost]
        public IActionResult Order(buynow buynow)
        {
            registerdb.buynow.Add(buynow);
            registerdb.SaveChanges();
            return RedirectToAction("Index");
        }




        public IActionResult buy(int id)
        {
            var data = dbcontext.addProducts.Find(id);
            return View(data);
        }
     
 
        public IActionResult salebuy(int id)
        {
            var data = dbcontext.addProductsales.Find(id);
            return View(data);
        }
 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
