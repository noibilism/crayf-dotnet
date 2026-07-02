using System.Threading.Tasks;

namespace Cray.Services
{
    public class WebhooksService : BaseService
    {
        public WebhooksService(CrayClient client) : base(client) { }

        public async Task<object> FailedPayoutWebhooks()
        {
            return await _client.GetAsync<object>("api/payout/failedWebhook");
        }

        public async Task<object> RetryFailedPayoutWebhook(string webhookId)
        {
            return await _client.GetAsync<object>($"api/payout/failedWebhook/{webhookId}");
        }
    }
}
