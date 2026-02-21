using System.Threading.Tasks;

namespace Cray.Services
{
    public class VirtualAccountsService : BaseService
    {
        public VirtualAccountsService(CrayClient client) : base(client) { }

        public async Task<object> Create(object data)
        {
            return await _client.PostAsync<object>("api/virtual-accounts/create", data);
        }

        public async Task<object> Initiate(object data)
        {
            return await _client.PostAsync<object>("api/virtual-accounts/initiate", data);
        }

        public async Task<object> List()
        {
            return await _client.GetAsync<object>("api/virtual-accounts/list");
        }

        public async Task<object> Providers()
        {
            return await _client.GetAsync<object>("api/virtual-accounts/providers");
        }

        public async Task<object> SubmitOtp(object data)
        {
            return await _client.PostAsync<object>("api/virtual-accounts/submit-otp", data);
        }
    }
}
