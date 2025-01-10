using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XM1.SportsData.Producer.Infrastructure.Configurations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySQL(
                "Server=localhost;Port=3306;Database=xmatch;User ID=root;Password=Aabb1010..",
                b => b.MigrationsAssembly("XM1.SportsData.Producer.Infrastructure")
            );

            return new DataContext(optionsBuilder.Options);
        }
    }
}
