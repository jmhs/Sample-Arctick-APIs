using System;
using System.Configuration;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using log4net;
using Newtonsoft.Json;

namespace HiveboxDemo.Controllers
{
    public class BaseController : Controller
    {
        private static readonly ILog DLog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private const string MAIN_DOMAIN_API_URL = "MainDomainApiUrl";
        private const string API_URL = "ApiUrl";
        private const string ADMIN_TOKEN = "AdminToken";
        private const string MERCHANT_TOKEN = "MerchantToken";
        private const string USER_TOKEN = "UserToken";
        private const string CLIENT_ID = "ClientId";
        private const string CLIENT_SECRET = "ClientSecret";

        public BaseController()
        {
        }

        public string MainDomainApiUrl
        {
            get
            {
                return ConfigurationManager.AppSettings[MAIN_DOMAIN_API_URL];
            }
        }

        private string ApiUrl {
            get {
                return ConfigurationManager.AppSettings[API_URL];
            }
        }

        protected string UserToken
        {
            get
            {
                var token = this.Request.Cookies["token"]?.Value;

                if (string.IsNullOrWhiteSpace(token))
                {
                    token = ConfigurationManager.AppSettings[USER_TOKEN];
                }
                return $"bearer {token}";
            }
            set
            {
                ConfigurationManager.AppSettings[USER_TOKEN] = value;
            }
        }

        public string ClientId
        {
            get
            {
                return ConfigurationManager.AppSettings[CLIENT_ID];
            }
        }
        public string ClientSecret
        {
            get
            {
                return ConfigurationManager.AppSettings[CLIENT_SECRET];
            }
        }

        public string RequestDomain
        {
            get
            {
                return Request.Url.GetLeftPart(UriPartial.Authority);
            }
        }
        

        protected async Task<T> DoPut<T>(string action, object data)
        {
            try
            {
                var url = $"{this.ApiUrl}{action}";
                string token = $"{this.UserToken}";

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", token);
                    HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    HttpResponseMessage tokenResponse = await httpClient.PutAsync(url, contentPost);
                    tokenResponse.EnsureSuccessStatusCode();
                    return await tokenResponse.Content.ReadAsAsync<T>();
                }                
            }
            catch (Exception exp)
            {
                DLog.Error(exp);
            }

            return default(T);
        }

        protected async Task<T> DoGet<T>(string action)
        {
            try
            {
                var url = $"{this.ApiUrl}{action}";
                string token = $"{this.UserToken}";

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", token);

                    HttpResponseMessage tokenResponse = await httpClient.GetAsync(url);

                    tokenResponse.EnsureSuccessStatusCode();

                    return await tokenResponse.Content.ReadAsAsync<T>();
                }
                
            }
            catch (Exception exp)
            {
                DLog.Error(exp);
            }

            return default(T);
        }

        protected async Task<T> DoPost<T>(string action, object data)
        {
            try
            {
                var url = $"{this.ApiUrl}{action}";
                string token = $"{this.UserToken}";

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", token);
                    HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    HttpResponseMessage tokenResponse = await httpClient.PostAsync(url, contentPost);
                    tokenResponse.EnsureSuccessStatusCode();
                    return await tokenResponse.Content.ReadAsAsync<T>();
                }                
            }
            catch (Exception exp)
            {
                DLog.Error(exp);
            }

            return default(T);
        }

        protected async Task<T> GetAccessToken<T>(string code)
        {
            
            try
            {
                var url = $"{this.MainDomainApiUrl}/token";
                string data = $"grant_type=authorization_code&client_id={ClientId}&client_secret={ClientSecret}&code={code}&redirect_uri={RequestDomain}/apitoken";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpContent contentPost = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpResponseMessage tokenResponse = await httpClient.PostAsync(url, contentPost);
                    tokenResponse.EnsureSuccessStatusCode();
                    return await tokenResponse.Content.ReadAsAsync<T>();
                }
            }
            catch (Exception exp)
            {
                DLog.Error(exp);
            }

            return default(T);
        }

        protected async Task<T> DoDelete<T>(string action)
        {
            try
            {
                var url = $"{this.ApiUrl}{action}";
                string token = $"{this.UserToken}";

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", token);
                    HttpResponseMessage tokenResponse = await httpClient.DeleteAsync(url);
                    tokenResponse.EnsureSuccessStatusCode();
                    return await tokenResponse.Content.ReadAsAsync<T>();
                }                
            }
            catch (Exception exp)
            {
                DLog.Error(exp);
            }

            return default(T);
        }
    }
}