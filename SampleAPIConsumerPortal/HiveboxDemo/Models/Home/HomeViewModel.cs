using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiveboxDemo.Models.Home
{
    public class HomeViewModel
    {
        public HomeViewModel() {
            Categories = new List<CategoryViewModel>();
            Items = new List<ItemViewModel>();
        }

        public IList<CategoryViewModel> Categories { get; set; }
        public IList<ItemViewModel> Items { get; set; }
    }
}