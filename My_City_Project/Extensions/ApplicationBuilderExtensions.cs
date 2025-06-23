using Microsoft.EntityFrameworkCore;
using My_City_Project.Data;
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
                dbContext.Database.Migrate();

                if (!dbContext.Users.Any(u => u.Role == "Admin"))
                {
                    dbContext.Users.Add(new User
                    {
                        Username = "ADMİN",
                        Password = "1234", 
                        Role = "Admin"
                    });
                    dbContext.SaveChanges();
                }
            }
        }
    }
}