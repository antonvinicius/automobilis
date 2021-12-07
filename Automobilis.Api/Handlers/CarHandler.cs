using Automobilis.Api.Services;
using Automobilis.Domain.Commands;
using Automobilis.Domain.Entities;
using Automobilis.Domain.Handlers;
using Automobilis.Domain.Repositories;
using Automobilis.Domain.Results;

namespace Automobilis.Api.Handlers
{
    public class CarHandler : IHandler<AlterCarCommand>
    {
        private readonly ICarRepository _repository;
        private readonly IConfiguration _configuration;

        public CarHandler(ICarRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<GenericResult> Handle(AlterCarCommand command)
        {
            var fileUp = new FileUpload(_configuration);

            if (command.Picture != null && command.CarId != 0)
            {
                if (command.CarId != 0 && !command.Picture.Contains("http"))
                {
                    var commandPic = fileUp.UploadBase64Image(command.Picture, "automobilis");
                    command.Picture = commandPic;
                }
            }
            else if (command.CarId == 0 && command.Picture != null)
            {
                var commandPic = fileUp.UploadBase64Image(command.Picture, "automobilis");
                command.Picture = commandPic;
            }
            else if (command.CarId == 0 && command.Picture == null)
            {
                command.Picture = "";
            }

            command.Price = command.Price / 100;

            if (command.CarId == 0)
            {
                var car = new Car(
                    command.BrandId,
                    command.Model,
                    command.FabYear,
                    command.ModelYear,
                    command.Price,
                    command.Description,
                    command.Picture);

                await _repository.Save(car);

                return new GenericResult(true, "Car created successfully", car);
            }
            else
            {
                var carToUpdate = await _repository.GetById(command.CarId);

                carToUpdate.BrandId = command.BrandId;
                carToUpdate.Picture = command.Picture;
                carToUpdate.Price = command.Price;
                carToUpdate.Description = command.Description;
                carToUpdate.FabYear = command.FabYear;
                carToUpdate.ModelYear = command.ModelYear;
                carToUpdate.Model = command.Model;

                await _repository.Update(carToUpdate);

                return new GenericResult(true, "Car updated successfully", carToUpdate);
            }
        }
    }
}
