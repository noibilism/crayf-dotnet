namespace Cray
{
    public class CrayConfig
    {
        public string BaseUrl { get; set; }
        public string Token { get; set; }
        public bool IsProduction { get; set; } = false;

        public CrayConfig(string baseUrl, string token)
        {
            BaseUrl = baseUrl;
            Token = token;
        }
    }
}
