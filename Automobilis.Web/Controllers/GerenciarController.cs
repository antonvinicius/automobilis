using Automobilis.Web.Data;
using Automobilis.Web.Models;
using Automobilis.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Automobilis.Web.Controllers
{
    public class GerenciarController : Controller
    {
        private readonly DataService _dataService;

        public GerenciarController(DataService dataService)
        {
            _dataService = dataService;
        }
        public IActionResult Index()
        {
            return View(_dataService.GetCars());
        }

        public IActionResult Add(int id)
        {
            ViewBag.BrandList = _dataService.GetBrands();
            if (id == 0)
                return View(new Car());
            else
                return View(_dataService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BrandList = _dataService.GetBrands();

                if (car.Id == 0)
                    return View("Add",new Car());
                else
                    return View("Add",_dataService.GetById(car.Id));
            }

            var fileUp = new FileUpload();
            
            if(car.Picture != null && car.Id != 0)
            {
                if (car.Id != 0 && !car.Picture.Contains("http"))
                {
                    var carPic = fileUp.UploadBase64Image(car.Picture, "automobilis");
                    car.Picture = carPic;
                }
                else if (car.Id == 0 && car.Picture != null)
                {
                    var carPic = fileUp.UploadBase64Image(car.Picture, "automobilis");
                    car.Picture = carPic;
                }
            }

            car.Price = car.Price / 100;

            if (car.Id == 0)
                _dataService.Save(car);
            else
                _dataService.Update(car);


            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _dataService.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
