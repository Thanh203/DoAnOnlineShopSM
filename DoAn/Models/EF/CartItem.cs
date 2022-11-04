using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn.Models.EF
{
    public class CartItem
    {
        OnlineShopSM db = new OnlineShopSM();
        public int ProductID { get; set; }
        public string NamePro { get; set; }
        public string ImagePro { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        //Tính FinalPrice = Price * Number
        public decimal FinalPrice()
        {
            return Number * Price;
        }
        public CartItem(int ProductID)
        {
            this.ProductID = ProductID;

            var productDB = db.Products.Single(s => s.ID == this.ProductID);
            this.NamePro = productDB.Name;
            this.ImagePro = productDB.Image;
            this.Price = (decimal)productDB.Price;
            this.Number = 1;
        }

    }
}