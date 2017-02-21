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
    public class OrderController : BaseController
    {

        // GET: Orders
        public async Task<ActionResult>  OrderHistory()
        {

           var responseStr =  await DoGet<List<OrderSimpleViewModel>>("/consumers/orders");

           //var result = JsonConvert.DeserializeObject<List<OrderSimpleViewModel>>(responseStr);

           return View(responseStr);
        }

        public async Task<ActionResult> OrderDetail(string id)
        {
            var responseStr = await DoGet<OrderFullViewModel>("/consumers/orders/" + id);

           // var result = JsonConvert.DeserializeObject<OrderFullViewModel>(responseStr);

            return View(responseStr);
        }
    }
}