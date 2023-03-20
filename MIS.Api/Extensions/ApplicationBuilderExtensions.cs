using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Net;

namespace MIS.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configures serilog for application
        /// </summary>
        /// <param name="builder">Builder for web application and services</param>
        /// <returns>Builder for web application and services</returns>
        public static WebApplicationBuilder ConfigureSerilog(this WebApplicationBuilder builder)
        {
            // remove default logging providers
            builder.Logging.ClearProviders();

            builder.Host.UseSerilog();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            builder.Logging.AddSerilog();

            return builder;
        }


        /// <summary>
        /// Adds a middleware to the pipeline that will catch exceptions, log them, 
        /// and re-execute the request in an alternate pipeline. The request will not be re-executed if 
        /// the response has already started.
        /// </summary>
        /// <param name="app">Application request pipeline</param>
        /// <returns>Application request pipeline</returns>
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                var error = exceptionHandlerPathFeature?.Error;

                context.Response.StatusCode = error switch
                {
                    ApplicationException => (int)HttpStatusCode.BadRequest,
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,
                    UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    context.Response.StatusCode,
                    Message = error?.Message ?? string.Empty
                });
            }));

            return app;
        }

        public static IApplicationBuilder UseSwaggerModule(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentname}/swagger.json";
            });

            app.UseSwaggerUI(config =>
            {
                config.DisplayRequestDuration();
                config.DefaultModelsExpandDepth(-1);
                config.DocExpansion(DocExpansion.None);
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                config.RoutePrefix = "swagger";
            });

            return app;
        }
    }
}
