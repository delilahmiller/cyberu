using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CyberU.Models
{
    public class EmailCheck
    {
        public async Task<List<EmailCheckResult>> CheckEmailAsync(string userName)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("hibp-api-key", "2258ca8b2c454f58a22ac207473d219c");

                using (var request = new HttpRequestMessage(HttpMethod.Get, "https://haveibeenpwned.com/api/v3/breachedaccount/" + userName + "?truncateResponse=false"))
                {
                    request.Method = HttpMethod.Get;

                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<EmailCheckResult>>(content);
                    }
                }
            }
        }
    }

    public class EmailCheckResult
    {
        public String Name;
        public String Title;
        public String Domain;
        public String BreachDate; // Format "2019-01-07"
        public String AddedDate; // Format "2019-01-16T21:46:07Z",
        public String ModifiedDate; // Format "2019-01-16T21:50:21Z",
        public int PwnCount;
        public String Description;
        public String LogoPath;
        public List<String> DataClasses;
        public bool IsVerified;
        public bool IsFabricated;
        public bool IsSensitive;
        public bool IsRetired;
        public bool IsSpamList;
    }
}