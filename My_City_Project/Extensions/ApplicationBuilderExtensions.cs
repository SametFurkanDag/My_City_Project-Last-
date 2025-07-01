using Microsoft.EntityFrameworkCore;
using My_City_Project.Data;
using My_City_Project.Helpers;
using My_City_Project.Model.Entities;

namespace My_City_Project.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrationsAndSeedAdmin(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                var passwordHelper = scope.ServiceProvider.GetRequiredService<IPasswordHelper>();

                dbContext.Database.Migrate();

                if (!dbContext.Users.Any(u => u.Role == "Admin"))
                {
                    var adminUser = new User
                    {
                        Id = Guid.NewGuid(),
                        Username = "admin",
                        Role = "Admin",
                        PasswordHash = passwordHelper.HashPassword("1234")
                    };

                    dbContext.Users.Add(adminUser);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
