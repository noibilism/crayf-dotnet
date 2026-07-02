using System.Threading.Tasks;

namespace Cray.Services
{
    public class CryptoPayoutsService : BaseService
    {
        public CryptoPayoutsService(CrayClient client) : base(client) { }

        public async Task<object> SupportedAssets()
        {
            return await _client.GetAsync<object>("api/virtual-accounts/crypto/supported-assets");
        }

        public async Task<object> AddBeneficiary(object data)
        {
            return await _client.PostAsync<object>("api/payout/crypto/beneficiaries", data);
        }

        public async Task<object> InitiatePayout(object data)
        {
            return await _client.PostAsync<object>("api/payout/crypto/initiate-payout", data);
        }
    }
}
