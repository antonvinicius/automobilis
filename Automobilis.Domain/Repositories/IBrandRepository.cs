using Automobilis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobilis.Domain.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAll();
    }
}
