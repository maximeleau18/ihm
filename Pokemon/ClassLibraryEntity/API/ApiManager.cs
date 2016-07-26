using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity.API
{
    public class ApiManager
    {
        private String urlApi {
            get { return "http://127.0.0.1:8000/api/"; }
        }

        public async Task<T> GetFromApi<T>(Int32 id)
        {
            T item = default(T);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlApi);
                HttpResponseMessage response = await client.GetAsync(typeof(T).Name.ToLower() + "/" + id);

                if (response.IsSuccessStatusCode)
                {
                    String result = await response.Content.ReadAsStringAsync();
                    item = JsonConvert.
                        DeserializeObject<T>(result);
                }
            }

            return item;
        }

        public async Task<T> GetListFromApi<T>()
        {
            T item = default(T);
            Type type = typeof(T).GenericTypeArguments[0];          

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlApi);
                HttpResponseMessage response = await client.GetAsync(typeof(T).GenericTypeArguments[0].Name.ToLower());

                if (response.IsSuccessStatusCode)
                {
                    String result = await response.Content.ReadAsStringAsync();
                    item = JsonConvert.DeserializeObject<T>(result);
                }
            }
            
            return item;
        }

        public async Task<Boolean> PostToApi<T>(T item)
        {
            Boolean isOk = false;

            using (Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient())
            {
                Windows.Web.Http.HttpRequestMessage message = new Windows.Web.Http.HttpRequestMessage(
                    Windows.Web.Http.HttpMethod.Post, new Uri(urlApi + typeof(T).Name.ToLower()));
                message.Content = new Windows.Web.Http.HttpStringContent(
                    JsonConvert.SerializeObject(item));
                
                message.Content.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("application/json");
                Windows.Web.Http.HttpResponseMessage response = await client.SendRequestAsync(message);
                
                if (response.IsSuccessStatusCode)
                {
                    isOk = true;
                }
            }

            return isOk;
        }

        public async Task<T> PostToApiAndReceiveData<T>(T item)
        {
            using (Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient())
            {
                Windows.Web.Http.HttpRequestMessage message = new Windows.Web.Http.HttpRequestMessage(
                    Windows.Web.Http.HttpMethod.Post, new Uri(urlApi + typeof(T).Name.ToLower()));
                message.Content = new Windows.Web.Http.HttpStringContent(
                    JsonConvert.SerializeObject(item));

                message.Content.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("application/json");
                Windows.Web.Http.HttpResponseMessage response = await client.SendRequestAsync(message);

                if (response.IsSuccessStatusCode)
                {
                    String result = await response.Content.ReadAsStringAsync();
                    item = JsonConvert. DeserializeObject<T>(result);
                }
            }

            return item;
        }

        public String PostToApiAndReceiveDataSync<T>(T item)
        {
            String result;

            using (Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient())
            {
                Windows.Web.Http.HttpRequestMessage message = new Windows.Web.Http.HttpRequestMessage(
                    Windows.Web.Http.HttpMethod.Post, new Uri(urlApi + typeof(T).Name.ToLower()));
                message.Content = new Windows.Web.Http.HttpStringContent(
                    JsonConvert.SerializeObject(item));

                message.Content.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("application/json");
                Windows.Web.Http.HttpResponseMessage response  = Task.Run(async () => await client.SendRequestAsync(message)).Result;
                
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().GetResults();
                }
                else
                {
                    result = response.Content.ReadAsStringAsync().GetResults();
                }
            }

            return result;
        }

        public async Task<String> PostToApiAndReceiveDataAsync<T>(T item)
        {
            String result;

            using (Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient())
            {
                Windows.Web.Http.HttpRequestMessage message = new Windows.Web.Http.HttpRequestMessage(
                    Windows.Web.Http.HttpMethod.Post, new Uri(urlApi + typeof(T).Name.ToLower()));
                message.Content = new Windows.Web.Http.HttpStringContent(
                    JsonConvert.SerializeObject(item));

                message.Content.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("application/json");
                Windows.Web.Http.HttpResponseMessage response = await client.SendRequestAsync(message);
                
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }

        public async Task<String> PostToApiCheckCredentialsAsync<T>(T item)
        {
            String result;

            using (Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient())
            {
                Windows.Web.Http.HttpRequestMessage message = new Windows.Web.Http.HttpRequestMessage(
                    Windows.Web.Http.HttpMethod.Post, new Uri(urlApi + typeof(T).Name.ToLower() + "/connexion"));
                message.Content = new Windows.Web.Http.HttpStringContent(
                    JsonConvert.SerializeObject(item));

                message.Content.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("application/json");
                Windows.Web.Http.HttpResponseMessage response = await client.SendRequestAsync(message);

                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}
