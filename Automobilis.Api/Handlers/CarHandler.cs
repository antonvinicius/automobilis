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
            // Instancia o serviço de upload de arquivos
            var fileUp = new FileUpload(_configuration);

            // Checa se é uma alteração da foto
            if (command.Picture != null && command.CarId != 0)
            {
                // Checa se a foto está no formato base64, aqui a foto foi alterada
                if (command.CarId != 0 && !command.Picture.Contains("http"))
                {
                    var commandPic = fileUp.UploadBase64Image(command.Picture, "automobilis");
                    command.Picture = commandPic;
                }
            }
            // Primeiro registro do carro com foto
            else if (command.CarId == 0 && command.Picture != null)
            {
                var commandPic = fileUp.UploadBase64Image(command.Picture, "automobilis");
                command.Picture = commandPic;
            }
            // Primeiro registro do carro sem foto
            else if (command.CarId == 0 && command.Picture == null)
            {
                command.Picture = "";
            }

            // O preço vem sem casas decimais do frontend
            command.Price = command.Price / 100;

            // Se é para salvar, instancia um novo carro
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
            // Atualizando um carro existente
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
