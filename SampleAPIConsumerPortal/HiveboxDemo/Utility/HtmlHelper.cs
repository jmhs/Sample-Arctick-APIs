using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiveboxDemo.Utility
{
    public static class HtmlHelperExtension
    {
        private const string API_URL = "ApiUrl";

        public static HtmlString ApiHost(this HtmlHelper htmlHelper)
        {
            var apiUrl = ConfigurationManager.AppSettings[API_URL];
            var uri = new Uri(apiUrl);
            return new HtmlString($"//{uri.Host}");
        }        
    }
}