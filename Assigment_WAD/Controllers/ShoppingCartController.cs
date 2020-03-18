using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assigment_WAD.Data;
using Assigment_WAD.Models;

namespace Assigment_WAD.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        private static Assigment_WADContext db = new Assigment_WADContext();
        private const String ShoppingCartSession = "SHOPPING_CART";

        public ActionResult AddItem(int productId, int quantity)
        {
            // Check product trong db
            var existingProduct = db.Products.FirstOrDefault(m => m.ProductID == productId);

            if (existingProduct == null)
            {
                return new HttpNotFoundResult();
            }
            var shoppingCart = GetShoppingCart();

            if (quantity == 1)
            {
                shoppingCart.Add(existingProduct, quantity, false);
            }
            else
            {
                shoppingCart.Add(existingProduct, quantity, true);
            }

            SetShoppingCart(shoppingCart);

            return RedirectToAction("ShowCart", "ShoppingCart");
        }
      
        public ActionResult ShowCart()
        {

            return View("ShowCart",GetShoppingCart());
        }

        public ActionResult CartStatus()
        {
            ViewBag.Quantity= GetShoppingCart().QuantityTotal;
            ViewBag.CartTotal = GetShoppingCart().CartTotal;
            return PartialView("~/Views/Shared_Project/Client/_Header.cshtml");
        }


        public ActionResult DeleteItem(int productID)
        {
            var shoppingCart = GetShoppingCart();
            shoppingCart.Remove(productID);
            SetShoppingCart(shoppingCart);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult UpdateCart(int productID, int quantity)
        {
            var existingProduct = db.Products.FirstOrDefault(m => m.ProductID == productID);

            if (existingProduct == null)
            {
                return new HttpNotFoundResult();
            }
            var shoppingCart = GetShoppingCart();
            shoppingCart.Update(existingProduct, quantity);
            SetShoppingCart(shoppingCart);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public ActionResult RemoveAll()
        {
            ClearShoppingCart();
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public ShoppingCart GetShoppingCart()
        {
            ShoppingCart shoppingCart = null;
            // Kiểm tra sự tòn tại của sc(shopping cart ) trong session
            if (Session[ShoppingCartSession] != null)
            {
                //nếu có
                try
                {
                    //Ép kiểu đối tượng lấy được  về kiểu ShoppingCart
                    shoppingCart = Session[ShoppingCartSession] as ShoppingCart;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
            }
            return shoppingCart;
        }

        private void SetShoppingCart(ShoppingCart shoppingCart)
        {
            Session[ShoppingCartSession] = shoppingCart;
        }

        private void ClearShoppingCart()
        {
            Session[ShoppingCartSession] = null;
        }
    }
}