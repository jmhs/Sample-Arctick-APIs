using HiveboxDemo.Models;
using HiveboxDemo.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HiveboxDemo.Controllers
{
    public class CartController : BaseController
    {

        // GET: Cart
        public async Task<ActionResult> Index()
        {
            var items = await this.DoGet<List<CartSimpleViewModel>>("/consumers/carts");

            //var items = JsonConvert.DeserializeObject<List<CartSimpleViewModel>>(responseStr);

            var model = new CartViewModel()
            {
                Items = items,
                Total = Convert.ToDecimal(items?.Sum(item => item.SubTotal))
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(int id)
        {
            if (id > 0)
            {
                var item = new CartAddModel()
                {
                    ItemId = id,
                    ItemQty = 1,
                    DeliveryId = 1, //Assumption that there's a delivery with an ID of '1'
                    DeliveryType = "delivery",
                    MarketPlaceTemplateType = "bespoke" //Assumption bespoke is currently used
                };
                await DoPost<string>("/consumers/carts/additem", item);
            }
             
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var responseStr = await DoDelete<bool>("/consumers/carts/deleteitem/"+id);

            //var result = JsonConvert.DeserializeObject<bool>(responseStr);

            return RedirectToAction("index");
        }

        [HttpPost]
        public async Task<ActionResult> Update(CartUpdateReq req)
        {

            if (req != null)
            {
                foreach(CartUpdateModel m in req.Data)
                {
                    string responseStr = await DoPut<string>("/consumers/carts/updateitem", m);
                }
            }

            return RedirectToAction("index");
        }       

        public class CartUpdateReq
        {
            public List<CartUpdateModel> Data { get; set; }
        }
    }
}