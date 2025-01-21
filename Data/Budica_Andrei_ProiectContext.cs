using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Budica_Andrei_Proiect.Models;

namespace Budica_Andrei_Proiect.Data
{
    public class Budica_Andrei_ProiectContext : DbContext
    {
        public Budica_Andrei_ProiectContext (DbContextOptions<Budica_Andrei_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Budica_Andrei_Proiect.Models.Pacient> Pacient { get; set; } = default!;
        public DbSet<Budica_Andrei_Proiect.Models.Terapeut> Terapeut { get; set; } = default!;
        public DbSet<Budica_Andrei_Proiect.Models.Programare> Programare { get; set; } = default!;
        public DbSet<Budica_Andrei_Proiect.Models.Plata> Plata { get; set; } = default!;
      
    }
}
