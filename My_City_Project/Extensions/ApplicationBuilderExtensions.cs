using Microsoft.EntityFrameworkCore;
using My_City_Project.Data;
using My_City_Project.Helpers;
using My_City_Project.Model.Entities;

namespace My_City_Project.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrationsAndSeedAdmin(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                var passwordHelper = scope.ServiceProvider.GetRequiredService<IPasswordHelper>();

                dbContext.Database.Migrate();

                if (!dbContext.Users.Any(u => u.Role == "Admin"))
                {
                    var hashedPassword = passwordHelper.HashPassword("1234");

                    dbContext.Users.Add(new User
                    {
                        Username = "ADMIN",
                        PasswordHash = hashedPassword,
                        Role = "Admin"
                    });
                    dbContext.SaveChanges();
                }
            }
        }

    }
}