using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiveboxDemo.Models.Item
{
    public class ItemViewModel
    {
        public ItemViewModel()
        {
            Images = new List<string>();
        }

        public int ID { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string PriceUnit { get; set; }
        public string BuyerDescription { get; set; }
        public decimal QtyLeft { get; set; }
        public bool StockLimited { get; set; }
        public IList<string> Images { get; set; }
    }
}