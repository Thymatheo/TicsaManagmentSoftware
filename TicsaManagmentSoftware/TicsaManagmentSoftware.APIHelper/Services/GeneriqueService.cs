using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TicsaManagmentSoftware.APIHelper.Services.Interfaces;

namespace TicsaManagmentSoftware.APIHelper.Services {
    public abstract class GeneriqueService<U> : IGeneriqueService<U> where U : class {

        protected static readonly string API_KEY_LABEL = "X-Api-Key";
        protected HelperConfig Config { get; set; }
        protected string ControllerName { get; set; }

        public GeneriqueService(HelperConfig config, string controllerName) {
            ControllerName = controllerName;
            Config = config;
        }

        public async Task<Response<IEnumerable<U>>> GetAll() {
            return await RequestHttpGet<Response<IEnumerable<U>>>("all");
        }

        public async Task<Response<U>> GetById(string route) {
            return await RequestHttpGet<Response<U>>(route);
        }

        public async Task<Response<U>> Delete(string route) {
            return await RequestHttpDelete<Response<U>>("remove/" + route);
        }

        public async Task<Response<IEnumerable<U>>> Post(object param) {
            return await RequestHttpPost<Response<IEnumerable<U>>>(param, "add");
        }

        public async Task<Response<U>> Put(object param, string route) {
            return await RequestHttpPut<Response<U>>(param, "update/" + route);
        }

        protected HttpClient GetClient() {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(API_KEY_LABEL, Config.AuthKey);
            return client;
        }
        protected StringContent BuildParam(object param) {
            return new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
        }

        protected string GetRoute(string route) {
            return Config.UrlApi + "/" + ControllerName + "/" + route;
        }

        protected async Task<T> RequestHttpGet<T>(string route = "") {
            using (HttpClient client = GetClient()) {
                HttpResponseMessage response = await client.GetAsync(GetRoute(route));
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }
        protected async Task<T> RequestHttpDelete<T>(string route = "") {
            using (HttpClient client = GetClient()) {
                HttpResponseMessage response = await client.DeleteAsync(GetRoute(route));
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }

        protected async Task<T> RequestHttpPost<T>(object param, string route = "") {
            using (HttpClient client = GetClient()) {
                HttpResponseMessage response = await client.PostAsync(GetRoute(route), BuildParam(param));
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }
        protected async Task<T> RequestHttpPut<T>(object param, string route = "") {
            using (HttpClient client = GetClient()) {
                HttpResponseMessage response = await client.PutAsync(GetRoute(route), BuildParam(param));
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
