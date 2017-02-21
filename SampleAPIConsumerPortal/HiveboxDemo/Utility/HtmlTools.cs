using log4net;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HiveboxDemo.Utility
{
    public class HtmlTools
    {
        private static readonly ILog DLog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<string> DoPut(string action, object data)
        {
            string result = "Failed";
            try
            {

                string url = ConfigurationManager.AppSettings["ApiUrl"] + action;
                string token = "Bearer " + ConfigurationManager.AppSettings["UserToken"];

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", token);
                    HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    HttpResponseMessage tokenResponse = await httpClient.PutAsync(url, contentPost);                    
                    tokenResponse.EnsureSuccessStatusCode();
                    result = await tokenResponse.Content.ReadAsStringAsync();                    
                }

                return result;
            }
            catch(Exception exp)
            {
                DLog.Error(exp);
            }

            return result;
        }

        public async Task<string> DoGet(string action)
        {
            string result = "Failed";
            try
            {

                string url = ConfigurationManager.AppSettings["ApiUrl"] + action;
                string token = "Bearer " + ConfigurationManager.AppSettings["UserToken"];

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", token);
                    HttpResponseMessage tokenResponse = await httpClient.GetAsync(url);                

                    tokenResponse.EnsureSuccessStatusCode();
                    result = await tokenResponse.Content.ReadAsStringAsync();
                }

                return result;
            }
            catch (Exception exp)
            {
                DLog.Error(exp);
            }

            return result;
        }

        public async Task<string> DoPost(string action,  object data)
        {
            string result = "Failed";
            try
            {

                string url = ConfigurationManager.AppSettings["ApiUrl"] + action;
                string token = "Bearer " + ConfigurationManager.AppSettings["UserToken"];

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", token);
                    HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    HttpResponseMessage tokenResponse = await httpClient.PostAsync(url, contentPost);
                    tokenResponse.EnsureSuccessStatusCode();
                    result = await tokenResponse.Content.ReadAsStringAsync();
                }

                return result;
            }
            catch (Exception exp)
            {
                DLog.Error(exp);
            }

            return result;
        }

        public async Task<string> DoDelete(string action)
        {
            string result = "Failed";
            try
            {

                string url = ConfigurationManager.AppSettings["ApiUrl"] + action;
                string token = "Bearer " + ConfigurationManager.AppSettings["UserToken"];

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", token);
                    HttpResponseMessage tokenResponse = await httpClient.DeleteAsync(url);
                    tokenResponse.EnsureSuccessStatusCode();
                    result = await tokenResponse.Content.ReadAsStringAsync();
                }

                return result;
            }
            catch (Exception exp)
            {
                DLog.Error(exp);
            }

            return result;
        }

    }
}
