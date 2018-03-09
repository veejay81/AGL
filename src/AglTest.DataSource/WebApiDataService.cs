using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AglTest.Data;

namespace AglTest.DataSource
{
    /// <summary>
    /// Web Api implementation of data service
    /// </summary>
    public class WebApiDataService : IDataService
    {
        private string baseUrl;
        private HttpClient client;

        /// <summary>
        /// Class initializer
        /// </summary>
        /// <param name="baseUrl">Base Url of Web Api</param>
        public WebApiDataService(string baseUrl)
        {
            this.baseUrl = baseUrl;

            this.client = new HttpClient();
            client.BaseAddress = new Uri(this.baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Fetch the pet owners
        /// </summary>
        /// <returns>Awaitable task for list of owners</returns>
        public async Task<IList<Owner>> FetchOwnersAsync()
        {
            List<Owner> owners = null;
            var response = await this.client.GetAsync("people.json");
            if (response.IsSuccessStatusCode)
            {
                owners = await response.Content.ReadAsAsync<List<Owner>>();
            }
            return owners;
        }
    }
}
