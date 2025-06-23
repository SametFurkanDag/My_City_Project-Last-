using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace My_City_Project.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var logger = context.RequestServices.GetRequiredService<ILoggerFactory>()
                                                        .CreateLogger("GlobalExceptionHandler");

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    logger.LogError(exception, "Unhandled exception occurred");

                    var result = new { message = "Beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyiniz." };
                    await context.Response.WriteAsJsonAsync(result);
                });
            });
        }

    }
}
