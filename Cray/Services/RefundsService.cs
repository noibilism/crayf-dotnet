using System.Threading.Tasks;

namespace Cray.Services
{
    public class RefundsService : BaseService
    {
        public RefundsService(CrayClient client) : base(client) { }

        public async Task<object> Initiate(object data)
        {
            return await _client.PostAsync<object>("api/v2/refund/initiate", data);
        }

        public async Task<object> Query(string reference)
        {
            return await _client.GetAsync<object>($"api/v2/refund/query/{reference}");
        }
    }
}
