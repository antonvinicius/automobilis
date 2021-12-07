using Automobilis.Domain.Entities;
using Automobilis.Domain.Repositories;
using Automobilis.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobilis.Infra.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int carId)
        {
            var car = await GetById(carId);
            if (car != null)
            {
                _context.Remove(car);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Cars!.Include(x => x.Brand).ToListAsync();
        }

        public async Task<Car> GetById(int carId)
        {
            return await _context.Cars.Include(x => x.Brand).FirstOrDefaultAsync(x => x.Id == carId);
        }

        public async Task<bool> Save(Car car)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Car> Update(Car car)
        {
            _context.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
