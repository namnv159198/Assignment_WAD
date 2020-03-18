using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assigment_WAD.Models
{
    public class ShoppingCart
    {
        public Dictionary<int, CartItems> Items { get; set; }

        public double CartTotal => Items.Values.Sum(m => m.TotalPrice);
        public double QuantityTotal => Items.Values.Sum(m => m.Quantity);
        public ShoppingCart()
        {
            Items = new Dictionary<int, CartItems>();
        }
        public class CartItems
        {
            public int id { get; set; }
            public String title { get; set; }
            public String Description { get; set; }
            [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
            public double Price { get; set; }

            public string Picture { get; set; }
            public Models.Product.EnumGender Gender { get; set; }
            public int Quantity { get; set; }

            [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
            [DisplayName("Total Price ")]
            public double TotalPrice => Price * Quantity;

            [ForeignKey("Category")]
            public int CategoryID { get; set; }
            public string Category { get; set; }
            
        }
        public void Add(Product product, int quantity, bool isUpdate)
        {
            var cart = new CartItems()
            {
                id = product.ProductID,
                title= product.Title,
                Description = product.Description,
                Picture = product.Picture,
                Quantity = quantity,
                Price = product.Price,
                CategoryID = product.CategoryID,
                Category = product.Category.CategoryName,
            };
            // kiểm tra tồn tại Product có trong giỏ hàng theo id chưa
            var existKey = Items.ContainsKey(product.ProductID);
            if (!isUpdate && existKey)
            {
                var existingItem = Items[product.ProductID];
                cart.Quantity += existingItem.Quantity;
            }

            if (existKey)
            {
                Items[product.ProductID] = cart;
            }
            else
            {
                Items.Add(product.ProductID, cart);
            }
        }

        public void Add(Product product)
        {
            Add(product, 1, false);
        }

        public void Update(Product product, int quantity)
        {
            Add(product, quantity, true);
        }

        public void Remove(int productId)
        {
            if (Items.ContainsKey(productId))
            {
                Items.Remove(productId);
            }
        }

    }
}