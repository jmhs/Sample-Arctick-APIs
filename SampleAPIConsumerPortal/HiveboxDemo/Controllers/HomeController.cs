using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HiveboxDemo.Controllers
{
    using Models.Home;

    public class HomeController : BaseController
    {
        #region Actions

        public async Task<ActionResult> Index()
        {
            var model = new HomeViewModel();            

            try
            {
                model.Categories = await GetCategories();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(model);
        }

        [Route("category/{id}")]
        public async Task<ActionResult> Category(int id)
        {
            var model = new HomeViewModel();

            try
            {
                model.Categories = await GetCategories();
                model.Items = await SearchItems(string.Empty, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View("Index", model);
        }

        [Route("search/{keyword?}")]
        public async Task<ActionResult> Search(string keyword)
        {
            var model = new HomeViewModel();

            try
            {
                model.Categories = await GetCategories();
                model.Items = await SearchItems(keyword, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View("Index", model);
        }

        #endregion

        #region Private Methods

        private async Task<IList<CategoryViewModel>> GetCategories()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var topRows = 15;
                var action = $"/consumers/categories?topRows={topRows}";

                var categories = await this.DoGet<IList<CategoryViewModel>>(action);
                return categories;
            }
        }
        private async Task<IList<ItemViewModel>> SearchItems(string keywords, int category)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var action = $"/consumers/items/search?keywords={keywords}&category={category}&page=1&pageSize=500";
                var items = await this.DoGet<IList<ItemViewModel>>(action);
                return items;
            }            
        }   
          
        #endregion
    }
}