using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public static string ConnectionString { get; set; } = string.Empty;
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public ApplicationDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
