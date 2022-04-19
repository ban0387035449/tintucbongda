using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tintucbongda.Models;

namespace tintucbongda.Data
{
    public class tintucbongdaContext : DbContext
    {
        public tintucbongdaContext (DbContextOptions<tintucbongdaContext> options)
            : base(options)
        {
        }

        public DbSet<tintucbongda.Models.timkiem> timkiem { get; set; }
    }
}
