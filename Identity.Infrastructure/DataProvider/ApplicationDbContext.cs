using Identity.Application.Common.Contracts;
using Identity.Domain.Entities;
using Identity.Infrastructure.DataProvider.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.DataProvider;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(builder);
    }
}