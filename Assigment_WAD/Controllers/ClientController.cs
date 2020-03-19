using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assigment_WAD.Data;
using Assigment_WAD.Models;
using PagedList;

namespace ASSIGNMENT_WAD.Controllers
{
    public class ClientController : Controller
    {
        private const String ShoppingCartSession = "SHOPPING_CART";

        private Assigment_WADContext db = new Assigment_WADContext();

        // GET: Client
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;

            var products = (from l in db.Products
                join c in db.Categories on l.CategoryID equals c.CategoryID
                select l).OrderBy(p=>p.ProductID);

               int pageSize = 12;

            int pageNumber = (page ?? 1);
            
            return View(products.ToPagedList(pageNumber , pageSize));
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

            return View("Boy",ListProduct.ToList());
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
        public ActionResult SearchTerm(String searchTerm)
        {

            var products = db.Products.Include(p => p.Category);
            if (searchTerm != null)
            {
                products = products.Where(p => p.Title.Contains(searchTerm));
            }
            switch (searchTerm)
            {
                case "Price_Asc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
            }
            ViewBag.SearchTerm = searchTerm;
            return View("Shop", products.ToList());
        }

        public ActionResult Contact()
        {
            return View("Contact");
        }

        public ActionResult PageListBoy(int? page)
        {
            if (page == null) page = 1;

            var products = (from l in db.Products
                join c in db.Categories on l.CategoryID equals c.CategoryID
                select l).OrderBy(p => p.ProductID);

            int pageSize = 8;
            var ListProduct = new List<Product>();
            int pageNumber = (page ?? 1);
            foreach (var i in products)
            {
                if (i.Gender == Product.EnumGender.Boy || i.Gender == Product.EnumGender.All)
                {
                    ListProduct.Add(i);
                }
            }
            return RedirectToAction("Boy",ListProduct.ToPagedList(pageNumber, pageSize));
        }
    }
}