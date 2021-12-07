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
    public class BrandRepository : IBrandRepository
    {
        private readonly DataContext _context;

        public BrandRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            return await _context.Brands!.ToListAsync();
        }
    }
}
