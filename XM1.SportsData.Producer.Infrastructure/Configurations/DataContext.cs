using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XM1.SportsData.Producer.Domain.Entities.Fixtures;
using XM1.SportsData.Producer.Domain.Entities.Leagues;
using XM1.SportsData.Producer.Domain.Entities.Teams;

namespace XM1.SportsData.Producer.Infrastructure.Configurations
{
    public class DataContext : DbContext
    {
        private static int _tableCounter = 1;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Partidas> Partidas { get; set; }
        public DbSet<Times> Times { get; set; }
        public DbSet<Liga> Ligas { get; set; }
        public DbSet<Pais> Paises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>().ToTable(GetTableName("Paises"));
            modelBuilder.Entity<Liga>().ToTable(GetTableName("Ligas"));
            modelBuilder.Entity<Times>().ToTable(GetTableName("Times"));
            modelBuilder.Entity<Partidas>().ToTable(GetTableName("Partidas"));
        }
        private string GetTableName(string entityName)
        {
            string formattedCounter = _tableCounter.ToString("D4");
            _tableCounter++;
            return $"XM1_TB{formattedCounter}_{entityName}".ToUpper();
        }
    }
}
