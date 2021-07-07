using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TicsaManagmentSoftware.APIHelper {
    public static class RequestAPI {
        public static HttpClient GetClient(string apiBaseUri) {
            HttpClient client = new HttpClient {
                BaseAddress = new Uri(apiBaseUri)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static async Task<T> GetReponseHttp<T>(Task<HttpResponseMessage> result) where T : class {
            HttpResponseMessage httpresponse = await result;
            if (httpresponse.IsSuccessStatusCode) {
                return JsonConvert.DeserializeObject<T>(await result.Result.Content.ReadAsStringAsync());
            }
            else {
                throw new HttpRequestException(result.Result.ReasonPhrase);
            }
        }
    }
}
