namespace Cray.Services
{
    public abstract class BaseService
    {
        protected readonly CrayClient _client;

        protected BaseService(CrayClient client)
        {
            _client = client;
        }
    }
}
