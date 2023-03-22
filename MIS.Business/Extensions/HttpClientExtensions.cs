using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Business.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> DeleteAsJsonAsync<TValue>(this HttpClient httpClient, string requestUri, TValue value)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = JsonContent.Create(value),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(requestUri, UriKind.Relative)
            };
            return await httpClient.SendAsync(request);
        }
    }
}
