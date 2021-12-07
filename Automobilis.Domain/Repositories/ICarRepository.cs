using Automobilis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobilis.Domain.Repositories
{
    public interface ICarRepository
    {
        Task<bool> Save(Car car);
        Task<Car> Update(Car car);
        Task<bool> Delete(int carId);
        Task<Car> GetById(int carId);
        Task<IEnumerable<Car>> GetAll();
    }
}
