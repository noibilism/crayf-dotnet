using System.Threading.Tasks;

namespace Cray.Services
{
    public class FxService : BaseService
    {
        public FxService(CrayClient client) : base(client) { }

        public async Task<object> Rate(object data)
        {
            return await _client.PostAsync<object>("api/rates", data);
        }

        public async Task<object> RatesByDestination(object data)
        {
            return await _client.PostAsync<object>("api/rates/destination", data);
        }

        public async Task<object> Quote(object data)
        {
            return await _client.PostAsync<object>("api/quote", data);
        }

        public async Task<object> Convert(object data)
        {
            return await _client.PostAsync<object>("api/conversions", data);
        }

        public async Task<object> History()
        {
            return await _client.GetAsync<object>("api/conversions");
        }

        public async Task<object> DisputeConversion(string conversionId, object data)
        {
            return await _client.PostAsync<object>($"api/conversions/{conversionId}/dispute", data);
        }
    }
}
