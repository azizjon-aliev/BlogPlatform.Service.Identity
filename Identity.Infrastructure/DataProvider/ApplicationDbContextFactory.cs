using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Identity.Infrastructure.DataProvider
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(basePath!, "Identity.API"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("ConnectionString:DefaultConnection"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}