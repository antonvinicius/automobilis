using Automobilis.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Automobilis.Web.Controllers
{
    public class CatalogoController : Controller
    {
        public async Task<IActionResult> Index([FromServices] CarService service)
        {
            var cars = await service.GetCarsAsync();
            return View(cars);
        }

        public async Task<IActionResult> Details([FromServices] CarService service, int id)
        {
            var car = await service.GetByIdAsync(id);
            return View(car);
        }
    }
}