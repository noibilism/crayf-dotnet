using System.Threading.Tasks;

namespace Cray.Services
{
    public class CryptoService : BaseService
    {
        public CryptoService(CrayClient client) : base(client) { }

        public async Task<object> SupportedAssets()
        {
            return await _client.GetAsync<object>("api/virtual-accounts/crypto/supported-assets");
        }

        public async Task<object> CreateVault(object data)
        {
            return await _client.PostAsync<object>("api/accounts/crypto/vault", data);
        }
    }
}
