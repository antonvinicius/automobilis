using Automobilis.Domain.Entities;
using Automobilis.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automobilis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepository _repository;

        public BrandsController(IBrandRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await _repository.GetAll();
        }
    }
}
