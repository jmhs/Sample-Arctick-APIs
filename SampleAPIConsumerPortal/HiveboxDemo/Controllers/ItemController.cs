using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace HiveboxDemo.Controllers
{
    using Models.Item;

    public class ItemController : BaseController
    {
        private static readonly ILog DLog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<ActionResult> Index(int id)
        {
            try
            {
                var item = await this.GetItemDetail(id);
                return View(item);
            }
            catch (Exception ex)
            {
                DLog.Error(ex);
            }

            return View(new ItemViewModel());
        }

        private async Task<ItemViewModel> GetItemDetail(int id)
        {
            var action = $"/consumers/items/{id}";
            var item = await this.DoGet<ItemViewModel>(action);
            return item;
        }
    }
}