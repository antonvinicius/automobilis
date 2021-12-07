using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Automobilis.Web.Models;

namespace Automobilis.Web.Data
{
    public class AutomobilisWebContext : DbContext
    {
        public AutomobilisWebContext (DbContextOptions<AutomobilisWebContext> options)
            : base(options)
        {
        }

        public DbSet<Automobilis.Web.Models.Car> Car { get; set; }
        public DbSet<Automobilis.Web.Models.Brand> Brand { get; set; }
    }
}
