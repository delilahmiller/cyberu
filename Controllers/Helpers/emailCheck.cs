using CyberU.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CyberU.Controllers
{
    public static class EmailCheck
    {
        public static async Task<List<EmailCheckResult>> CheckEmailAsync(string userName)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Cyberu.online");

                using (var request = new HttpRequestMessage(HttpMethod.Get, "https://haveibeenpwned.com/api/v3/breachedaccount/" + userName + "?truncateResponse=false"))
                {
                    request.Method = HttpMethod.Get;
                    request.Headers.Add("hibp-api-key", "2258ca8b2c454f58a22ac207473d219c");
                        
                    using (var response = await client.SendAsync(request))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<List<EmailCheckResult>>(content);
                        }
                        else
                        {
                            return new List<EmailCheckResult>();
                        }
                    }
                }
            }
        }
    }


}