using Identity.Application.Common.Contracts.Services;
using Identity.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Identity.Infrastructure.DataProvider;

public static class DataSeeder
{
    public static async Task SeedAsync(this ApplicationDbContext context, ILogger logger, IPasswordService service)
    {
        try
        {
            if (!context.Users.Any())
            {
                await Task.Run(async () =>
                {
                    var hashPassword = service.HashPassword("password123");
                    var users = new List<User>()
                    {
                        new User
                        {
                            Username = "Admin", Email = "admin@gmail.com",
                            Password = hashPassword
                        },
                        new User
                        {
                            Username = "Moderator", Email = "moderator@gmail.com",
                            Password = hashPassword
                        },
                        new User
                        {
                            Username = "Adam", Email = "adam@gmail.com", Password = hashPassword
                        },
                        new User
                        {
                            Username = "John", Email = "john@gmail.com", Password = hashPassword
                        }
                    };
                    await context.AddRangeAsync(users);

                    await context.SaveChangesAsync();
                });
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception error while entering demo data: {Message}", ex.Message);
        }
    }
}