using Automobilis.Web.Data;
using Automobilis.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Automobilis.Web.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly DataService _dataService;

        public CatalogoController(DataService dataService)
        {
            _dataService = dataService;
        }
        public IActionResult Index()
        {
            return View(_dataService.GetCars());
        }

        public IActionResult Details(int id)
        {
            return View(_dataService.GetById(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}