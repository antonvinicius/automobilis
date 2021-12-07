using Automobilis.Domain.Commands;
using Automobilis.Domain.Entities;
using Automobilis.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Automobilis.Web.Controllers
{
    public class GerenciarController : Controller
    {
        private readonly CarService _carService;
        private readonly BrandService _brandService;

        public GerenciarController([FromServices] CarService carService, [FromServices] BrandService brandService)
        {
            _carService = carService;
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetCarsAsync();
            return View(cars);
        }

        public async Task<IActionResult> Add(int id)
        {
            ViewBag.BrandList = await _brandService.GetBrandsAsync();
            if (id == 0)
                return View(new Car());
            else
                return View(await _carService.GetByIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BrandList = await _brandService.GetBrandsAsync();

                if (car.Id == 0)
                    return View("Add",new Car());
                else
                    return View("Add", await _carService.GetByIdAsync(car.Id));
            }

            var command = new AlterCarCommand(
                car.Id,
                car.BrandId,
                car.Model,
                car.FabYear,
                car.ModelYear,
                car.Price,
                car.Description,
                car.Picture);

            await _carService.AlterCarAsync(command);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _carService.DeleteCarAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
