using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiveboxDemo.Models.Home
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            ChildCategories = new List<CategoryViewModel>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryID { get; set; }
        public int SortOrder { get; set; }
        public IList<CategoryViewModel> ChildCategories { get; set; }
        public string ImageUrl { get; set; }
    }
}