using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiveboxDemo.Models
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            Items = new List<CartSimpleViewModel>();
        }
        public decimal Total { get; set; }
        public List<CartSimpleViewModel> Items { get; set; }
    }

    public class CartSimpleViewModel
    {
        public int ID { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public string ItemTitle { get; set; }
        public decimal SubTotal { get; set; }
    }

    public class CartAddModel
    {
        public int ItemId { get; set; }
        public decimal ItemQty { get; set; }
        public int? DeliveryId { get; set; }
        public string DeliveryType { get; set; }
        public string MarketPlaceTemplateType { get; set; }        
    }

    public class CartUpdateModel : CartAddModel
    {
        public int CartItemId { get; set; }
        public bool IsAppendQty { get; set; }
    }


}