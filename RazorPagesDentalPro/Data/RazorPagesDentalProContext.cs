using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesDentalPro.Models;

namespace RazorPagesDentalPro.Data
{
    public class RazorPagesDentalProContext : DbContext
    {
        public RazorPagesDentalProContext (DbContextOptions<RazorPagesDentalProContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesDentalPro.Models.Dentist> Dentist { get; set; }

        public DbSet<RazorPagesDentalPro.Models.Pacient> Pacient { get; set; }
    }
}
