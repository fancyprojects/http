using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace FancyProjects.Http
{
    public class HttpService : IHttpService
    {
        public TResult Get<TResult>(string url)
        {
            var request = new HttpClient();
            var response = request.GetAsync(url).Result;
            if (!response.IsSuccessStatusCode)
                throw new IntegrationException("Can not get data from " + url);
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<TResult>(json);
        }

        public TResult Post<TResult>(string url, object data)
        {
            var request = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = request.PostAsync(url, content).Result;

            if (!response.IsSuccessStatusCode)
                throw new IntegrationException("Can not post data to " + url);
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<TResult>(json);
        }
        public TResult Put<TResult>(string url, object data)
        {
            var request = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = request.PutAsync(url, content).Result;

            if (!response.IsSuccessStatusCode)
                throw new IntegrationException("Can not post data to " + url);
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<TResult>(json);
        }

        public TResult Delete<TResult>(string url)
        {
            var request = new HttpClient();
            var response = request.DeleteAsync(url).Result;
            if (!response.IsSuccessStatusCode)
                throw new IntegrationException("Can not delete from " + url);
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<TResult>(json);
        }
    }
}