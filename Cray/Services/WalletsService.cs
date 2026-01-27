using System.Threading.Tasks;

namespace Cray.Services
{
    public class WalletsService : BaseService
    {
        public WalletsService(CrayClient client) : base(client) { }

        public async Task<object> Balance()
        {
            return await _client.GetAsync<object>("api/balance");
        }

        public async Task<object> Subaccounts()
        {
            return await _client.GetAsync<object>("api/get-subaccount");
        }
    }
}
