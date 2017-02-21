using HiveboxDemo.Models.Login;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HiveboxDemo.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [Route("logout")]
        public ActionResult Logout(string provider)
        {
            var cookie = new HttpCookie("token");
            cookie.Expires = DateTime.Now.AddDays(-1d);
            this.Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Home");
        }

        [Route("login")]
        public ActionResult login()
        {
            return View("Index");
        }

        [Route("redirect/{provider}")]
        public ActionResult redirect(string provider)
        {
            var url = String.Format("{0}/api/account/externallogin?provider={1}&response_type=code&client_id={2}&scope=basic&redirect_uri={3}/apitoken", MainDomainApiUrl, provider, ClientId, RequestDomain);
            return Redirect(url);
        } 

        [Route("apitoken")]
        public async Task<ActionResult> AfterLogin(string code)
        {
            var response = await GetAccessToken<AccessTokenModel>(code);
            if (!string.IsNullOrWhiteSpace(response?.access_token))
            {
                var accessToken = response.access_token;

                //store token somewhere
                StoreToken(accessToken);

                //this.UserToken = accessToken;
                return RedirectToAction("Index", "Home");
            }
            else {
                return RedirectToAction("");
            }            
        }

        private void StoreToken(string token)
        {
            //Store cookie to response
            var cookie = new HttpCookie("token", token);
            this.Response.Cookies.Add( cookie);
        }
    }
}