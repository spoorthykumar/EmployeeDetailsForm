using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailsForm
{
    public static class RestAPIHelper
    {
        private static readonly string baseURL = "https://gorest.co.in/public/v2/";
        public static async Task<string> GetAllEmployees()
        {
            using (HttpClient client = new HttpClient()) 
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + "users"))
                {
                    using (HttpContent content = res.Content) 
                    {
                        string data = await content.ReadAsStringAsync();
                        if(data != null) 
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static string FormatJson(string jsonStr)
        {
            JToken formatData = JToken.Parse(jsonStr);
            return formatData.ToString(Formatting.Indented);
        }

        public static async Task<string> ViewEmployee(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + "users/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static async Task<string> SearchEmployee(string firstName)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + "users?name=" + firstName))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static async Task<string> SearchPage(string pageNum)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + "users?page=" + pageNum))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
