using EcommerceShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EcommerceShop.Controllers
{
    public class adminproductController : Controller
    {
        private readonly MyDbcontext dbcontext;

        public adminproductController(MyDbcontext dbcontext , IWebHostEnvironment web)
        {
            this.dbcontext = dbcontext;
            Web = web;
        }

        public IWebHostEnvironment Web { get; }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                ViewData["addproduct"] = dbcontext.addProducts;
                ViewBag.category_name = new SelectList(dbcontext.addCategories, "id", "category_name");
                return View();
            }
            return RedirectToAction("login", "adminlogin");
           
        }
        [HttpPost]
        public IActionResult Index(AddProduct product , IFormFile Product_Images)
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var location = Path.Combine(Web.WebRootPath, "addproductimg", Product_Images.FileName);
                FileStream file = new FileStream(location, FileMode.Create);
                Product_Images.CopyTo(file);
                product.Product_Images = Product_Images.FileName;
                dbcontext.addProducts.Add(product);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("login", "adminlogin");
           
          
        }
        public IActionResult ShowProduct()
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                var data = dbcontext.addProducts.Include(b => b.AddCategory).ToList();
                return View(data);
            }
            return RedirectToAction("login", "adminlogin");
            

        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("adminlogin") != null)
            {
                ViewBag.category_name = new SelectList(dbcontext.addCategories, "id", "category_name");
                var data = dbcontext.addProducts.Find(id);
                return View(data);
            }
            return RedirectToAction("login", "adminlogin");
          
        }
        [HttpPost]
        public IActionResult Edit(AddProduct product , IFormFile Product_Images)
        {
            var data = dbcontext.addProducts.Where(a => a.Product_id == product.Product_id).FirstOrDefault();
            if(Product_Images != null && Product_Images.Length>0)
            {
                  var old_img = Path.Combine(Web.WebRootPath, "addproductimg", data.Product_Images);
            if (System.IO.File.Exists(old_img))
            {
                System.IO.File.Delete(old_img);
            }
                var location = Path.Combine(Web.WebRootPath, "addproductimg", Product_Images.FileName);
                FileStream file = new FileStream(location, FileMode.Create);
                Product_Images.CopyTo(file);
                data.Product_Images = Product_Images.FileName;
            }
            else
            {
                product.Product_Images = data.Product_Images;
            }
            data.Product_Name = product.Product_Name;
            data.Product_Price = product.Product_Price;
            data.Product_Details = product.Product_Details;
            data.category_list = product.category_list;
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var data = dbcontext.addProducts.Find(id);
            return View(data);
        }
        public IActionResult CDelete(int id , AddProduct add)
        {
            var data = dbcontext.addProducts.Find(id);
            var old_img = Path.Combine(Web.WebRootPath, "addproductimg", data.Product_Images);
            if (System.IO.File.Exists(old_img))
            {
                System.IO.File.Delete(old_img);
            }

            dbcontext.addProducts.Remove(data);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
