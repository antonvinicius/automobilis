using Automobilis.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Automobilis.Web.Data
{
    public class DataService
    {
        private readonly AutomobilisWebContext _context;

        public DataService(AutomobilisWebContext context)
        {
            _context = context;
            if (_context.Brand.Count() == 0)
            {
                _context.Brand.AddRange(MyDb.GetBrands());
                _context.SaveChanges();
            }
        }

        public List<Car> GetCars()
        {
            return _context.Car.Include(x => x.Brand).ToList();
        }

        public Car GetById(int id)
        {
            return _context.Car.Include(x => x.Brand).FirstOrDefault(x => x.Id == id);
        }

        public List<Brand> GetBrands()
        {
            return _context.Brand.ToList();
        }

        public void DeleteCar(int id)
        {
            var car = GetById(id);
            _context.Remove(car);
            _context.SaveChanges();
        }

        public void Save(Car car)
        {
            _context.Add(car);
            _context.SaveChanges();
        }

        public void Update(Car car)
        {
            _context.Update(car);
            _context.SaveChanges();
        }
    }
}
