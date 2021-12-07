    using Automobilis.Domain.Commands;
using Automobilis.Domain.Entities;

namespace Automobilis.Web.Services
{
    public class CarService
    {
        private readonly HttpClient _http;
        public IConfiguration _configuration { get; set; }
        public string uri { get; set; }

        public CarService(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
            uri = _configuration.GetSection("ApiEndpoint").Value;
        }

        public async Task<IEnumerable<Car>> GetCarsAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<Car>>($"{uri}/Cars");
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Car>($"{uri}/Cars/{id}");
        }

        public async Task AlterCarAsync(AlterCarCommand command)
        {
            var result = await _http.PostAsJsonAsync($"{uri}/Cars", command);
        }

        public async Task DeleteCarAsync(int carId)
        {
            var result = await _http.DeleteAsync($"{uri}/Cars/{carId}");
        }
    }
}
