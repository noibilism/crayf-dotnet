using System.Threading.Tasks;

namespace Cray.Services
{
    public class PayoutsService : BaseService
    {
        public PayoutsService(CrayClient client) : base(client) { }

        public async Task<object> PaymentMethods(string countryCode)
        {
            return await _client.GetAsync<object>($"api/payout/payment-methods/{countryCode}");
        }

        public async Task<object> Banks(string countryCode = null)
        {
            var url = "api/payout/banks";
            if (!string.IsNullOrEmpty(countryCode))
            {
                url += $"?countryCode={countryCode}";
            }
            return await _client.GetAsync<object>(url);
        }

        public async Task<object> ValidateAccount(object data)
        {
            return await _client.PostAsync<object>("api/payout/accounts/validate", data);
        }

        public async Task<object> Disburse(object data)
        {
            return await _client.PostAsync<object>("api/payout/disburse", data);
        }

        public async Task<object> Verify(string transactionId)
        {
            return await _client.GetAsync<object>($"api/payout/requery/{transactionId}");
        }
    }
}
