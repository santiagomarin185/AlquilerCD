using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luisde_Prestamos_Cd.models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
      public DbSet<Clientes> Clientes { get; set;}
      public DbSet<Cds> Cds { get; set; }
      public DbSet<Alquileres> Alquileres { get; set; }
      public DbSet<DetalleAlquileres> DetalleAlquileres { get; set; }
      public DbSet<Sanciones> Sanciones { get; set; }
      
     
     
    }
}
