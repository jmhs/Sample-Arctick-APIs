using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiveboxDemo.Models.Home
{
    public class ItemViewModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string ItemName { get; set; }
        public string BuyerDescription { get; set; }
        public decimal Price { get; set; }
        public string PriceUnit { get; set; }
        public bool StockLimited { get; set; }
        public decimal? StockQuantity { get; set; }
        public string CurrencyCode { get; set; }
        public string ImageUrl { get; set; }
        public decimal? AverageRating { get; set; }
    }
}