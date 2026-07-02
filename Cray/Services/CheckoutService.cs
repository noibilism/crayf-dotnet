using System.Threading.Tasks;

namespace Cray.Services
{
    public class CheckoutService : BaseService
    {
        public CheckoutService(CrayClient client) : base(client) { }

        public async Task<object> Initialize(object data)
        {
            return await _client.PostAsync<object>("api/checkout/initialize", data);
        }

        public async Task<object> Query(string reference)
        {
            return await _client.GetAsync<object>($"api/checkout/query/{reference}");
        }
    }
}
