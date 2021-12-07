using Automobilis.Api.Commands;
using Automobilis.Api.Handlers;
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

        public CarsController(ICarRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Car>> GetCarsAsync()
        {
            return await _repository.GetAll();
        }

        [HttpPost]
        public async Task<GenericResult> AlterCarAsync(AlterCarCommand alterCarCommand, [FromServices] CarHandler handler)
        {
            return await handler.Handle(alterCarCommand);
        }

        [HttpDelete]
        public async Task<bool> DeleteCarAsync(DeleteCarCommand command)
        {
            await _repository.Delete(command.CarId);
            return true;
        }
    }
}
