using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scanner.Client.BusinessLogic.Services {
    public class BaseService {
        private readonly HttpClient _client;

        public BaseService() {
            _client = new HttpClient();
        }

        public virtual async Task<JToken> GetAsync(string url, string endpoint, CancellationToken cancellationToken) {
            var uri = new Uri($"{url}{endpoint}");
            var response = await _client.GetAsync(uri, cancellationToken);
            var result = await response.Content.ReadAsStringAsync();

            return JToken.Parse(result);
        }

        public virtual async Task<JToken> PostAsync(string url, string endpoint, JObject jObj, CancellationToken cancellationToken) {
            var uri = new Uri($"{url}{endpoint}");
            var content = new StringContent(jObj.ToString(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(uri, content);
            var result = await response.Content.ReadAsStringAsync();

            return JToken.Parse(result);
        }
    }
}
