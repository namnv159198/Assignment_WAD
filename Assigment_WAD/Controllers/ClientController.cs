using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assigment_WAD.Data;
using Assigment_WAD.Models;

namespace ASSIGNMENT_WAD.Controllers
{
    public class ClientController : Controller
    {
        private const String ShoppingCartSession = "SHOPPING_CART";

        private Assigment_WADContext db = new Assigment_WADContext();

        // GET: Client
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);

            return View(products.ToList());
        }
    
        public ActionResult Cart()
        {
            return RedirectToAction("ShowCart","ShoppingCart");
        }
        public ActionResult SingleProduct(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult Boy(string sortOrder, int categoryID = 0)
        {
            var categories = from c in db.Categories select c;
            ViewBag.categoryID = new SelectList(categories, "CategoryID", "CategoryName"); // danh sách Category
           

            var products = db.Products.Include(p => p.Category);
            if (categoryID != 0)
            {
                products = products.Where(x => x.CategoryID == categoryID);
            }
            var ListProduct = new List<Product>();
            foreach (var i in products)
            {
                if (i.Gender == Product.EnumGender.Boy || i.Gender == Product.EnumGender.All)
                {
                    ListProduct.Add(i);
                }
            }
            
            switch (sortOrder)
            {
                case "Price_Asc":
                    ListProduct = ListProduct.OrderByDescending(p=>p.Price).ToList();
                    break;
                case "Price_Desc":
                    ListProduct = ListProduct.OrderBy(p => p.Price).ToList();
                    break;
                case "Title_Asc":
                    ListProduct = ListProduct.OrderByDescending(s => s.Title).ToList();
                    break;
                case "Title_Desc":
                    ListProduct = ListProduct.OrderBy(p => p.Title).ToList();
                    break;
            }

            return View(ListProduct.ToList());
        }
        public ActionResult Girl(string sortOrder, int categoryID = 0)
        {
            var categories = from c in db.Categories select c;
            ViewBag.categoryID = new SelectList(categories, "CategoryID", "CategoryName"); // danh sách Category


            var products = db.Products.Include(p => p.Category);
            if (categoryID != 0)
            {
                products = products.Where(x => x.CategoryID == categoryID);
            }
            var ListProduct = new List<Product>();
            foreach (var i in products)
            {
                if (i.Gender == Product.EnumGender.Girl || i.Gender == Product.EnumGender.All)
                {
                    ListProduct.Add(i);
                }
            }

            switch (sortOrder)
            {
                case "Price_Asc":
                    ListProduct = ListProduct.OrderByDescending(p => p.Price).ToList();
                    break;
                case "Price_Desc":
                    ListProduct = ListProduct.OrderBy(p => p.Price).ToList();
                    break;
                case "Title_Asc":
                    ListProduct = ListProduct.OrderByDescending(s => s.Title).ToList();
                    break;
                case "Title_Desc":
                    ListProduct = ListProduct.OrderBy(p => p.Title).ToList();
                    break;
            }

            return View(ListProduct.ToList());
        }
        public ActionResult Blog()
        {
            return View("Blog");
        }
        public ActionResult Checkout()
        {
            return View("Checkout");
        }
        public ActionResult Login_Register()
        {
            return View("Login_Register");
        }
        public ActionResult Shop()
        {
            return View("Shop");
        }
        public ActionResult Contact()
        {
            return View("Contact");
        }

        public ActionResult SortPrice(String sort)
        {
            var products = db.Products.Include(s => s.CategoryID);
            switch (sort)
            {
                // 3.1 Nếu biến sortOrder sắp giảm thì sắp giảm theo LinkName
                case "Asc":
                    products = db.Products.OrderByDescending(s => s.Price);
                    break;

                // 3.2 Mặc định thì sẽ sắp tăng
                default:
                    products = db.Products.OrderBy(s => s.Price);
                    break;
            }

            return View("Boy",products);
        }
    }
}