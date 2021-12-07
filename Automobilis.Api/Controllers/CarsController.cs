using Automobilis.Api.Handlers;
using Automobilis.Domain.Commands;
using Automobilis.Domain.Entities;
using Automobilis.Domain.Repositories;
using Automobilis.Domain.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automobilis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _repository;
        private readonly CarHandler _handler;

        public CarsController(ICarRepository repository, CarHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        public async Task<IEnumerable<Car>> GetCarsAsync()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<Car> GetCarsAsync(int id)
        {
            return await _repository.GetById(id);
        }

        [HttpPost]
        public async Task<GenericResult> AlterCarAsync(AlterCarCommand alterCarCommand)
        {
            return await _handler.Handle(alterCarCommand);
        }

        [HttpDelete("{id:int}")]
        public async Task<bool> DeleteCarAsync(int id)
        {
            await _repository.Delete(id);
            return true;
        }
    }
}
