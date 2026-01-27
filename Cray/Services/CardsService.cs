using System.Threading.Tasks;
using System.Collections.Generic;

namespace Cray.Services
{
    public class CardsService : BaseService
    {
        public CardsService(CrayClient client) : base(client) { }

        public async Task<object> Initiate(object data)
        {
            return await _client.PostAsync<object>("api/v2/initiate", data);
        }

        public async Task<object> Charge(object data)
        {
            return await _client.PostAsync<object>("api/v2/charge", data);
        }

        public async Task<object> Query(string reference)
        {
            return await _client.GetAsync<object>($"api/query/{reference}");
        }
    }
}
