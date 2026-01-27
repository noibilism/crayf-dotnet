using System.Threading.Tasks;

namespace Cray.Services
{
    public class MoMoService : BaseService
    {
        public MoMoService(CrayClient client) : base(client) { }

        public async Task<object> Initiate(object data)
        {
            return await _client.PostAsync<object>("api/v2/momo/initiate", data);
        }

        public async Task<object> Requery(string customerReference)
        {
            return await _client.GetAsync<object>($"api/v2/momo/requery/{customerReference}");
        }
    }
}
