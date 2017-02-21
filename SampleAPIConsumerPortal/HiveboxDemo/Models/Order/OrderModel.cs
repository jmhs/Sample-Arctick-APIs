using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiveboxDemo.Models
{
    public class OrderSimpleViewModel
    {
        public string InvoiceId { get; set; }
    }

    public class OrderFullViewModel
    {

        public string DeliveryName { get; set; }
        public string InvoiceId { get; set; }
        public string TimeStamp { get; set; }
        public string Gateway { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string GrandTotal { get; set; }
        public string Total { get; set; }
        public string Freight { get; set; }
        public string BulkDeliveryDiscount { get; set; }

        public List<CartItem> CartItems { get; set; }


        public class CartItem
        {

            public int Id { get; set; }
            public int ItemId { get; set; }
            public string ItemName { get; set; }
            public string InvoiceId { get; set; }
            public string Time { get; set; }
            public string Qty { get; set; }
            public string DeliveryType { get; set; }
            public string Fee { get; set; }
            public string Address { get; set; }
            public string CartItemStatus { get; set; }
            public string Price { get; set; }

            public string PriceUnit { get; set; }
            public string Notes { get; set; }

            public string MerchantEmail { get; set; }
            public string MerchantContact { get; set; }
            public string Location { get; set; }
            public string TotalPrice { get; set; }
        }
    }
}