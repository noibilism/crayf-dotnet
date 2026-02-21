using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Cray.Exceptions;
using Cray.Services;

namespace Cray
{
    public class CrayClient
    {
        private readonly HttpClient _httpClient;
        private readonly CrayConfig _config;

        public CardsService Cards { get; }
        public MoMoService MoMo { get; }
        public WalletsService Wallets { get; }
        public FxService FX { get; }
        public PayoutsService Payouts { get; }
        public RefundsService Refunds { get; }
        public VirtualAccountsService VirtualAccounts { get; }

        public CrayClient(string baseUrl, string token)
        {
            _config = new CrayConfig(baseUrl, token);
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Cards = new CardsService(this);
            MoMo = new MoMoService(this);
            Wallets = new WalletsService(this);
            FX = new FxService(this);
            Payouts = new PayoutsService(this);
            Refunds = new RefundsService(this);
            VirtualAccounts = new VirtualAccountsService(this);
        }

        public async Task<T> PostAsync<T>(string endpoint, object data)
        {
            return await SendRequestAsync<T>(HttpMethod.Post, endpoint, data);
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            return await SendRequestAsync<T>(HttpMethod.Get, endpoint, null);
        }

        private async Task<T> SendRequestAsync<T>(HttpMethod method, string endpoint, object data)
        {
            var request = new HttpRequestMessage(method, endpoint);

            if (data != null)
            {
                var json = JsonSerializer.Serialize(data);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            try
            {
                var response = await _httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    HandleError(response, content);
                }

                return JsonSerializer.Deserialize<T>(content);
            }
            catch (HttpRequestException ex)
            {
                throw new CrayException("Network error occurred.", ex);
            }
        }

        private void HandleError(HttpResponseMessage response, string content)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new AuthenticationException("Unauthorized access. Check your API token.");
            }

            if ((int)response.StatusCode == 422 || response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ValidationException($"Validation error: {content}");
            }

            throw new RequestException($"API request failed with status {response.StatusCode}", (int)response.StatusCode, content);
        }
    }
}
