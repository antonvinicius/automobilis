using Automobilis.Domain.Entities;

namespace Automobilis.Web.Services
{
    public class BrandService
    {
        private readonly HttpClient _http;
        public IConfiguration _configuration { get; set; }
        public string uri { get; set; }

        public BrandService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
            uri = _configuration.GetSection("ApiEndpoint").Value;
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<Brand>>($"{uri}/Brands");
        }
    }
}
