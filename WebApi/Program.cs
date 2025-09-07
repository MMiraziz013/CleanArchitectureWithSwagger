using System.Net;
using Clean.Application;
using Clean.Application.Services;
using Clean.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // The service registrations are now handled by extension methods.
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices();
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            // This enables the Swagger middleware to serve the generated API specification as a JSON file.
            app.UseSwagger();

            // This enables the Swagger UI middleware, which uses the JSON file to generate the
            // interactive documentation page. This is the crucial part that was missing.
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty; // Set the route prefix to an empty string
            });

            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/error");
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        

        app.MapControllers();

        app.Map("/error", (HttpContext context) =>
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error;

            // Default to a 500 Internal Server Error.
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var title = "An unexpected error occurred.";

            // Check the type of the exception to return a more specific status code.
            if (exception is ArgumentException || exception is System.ComponentModel.DataAnnotations.ValidationException)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
                title = "Invalid input.";
            }
            else if (exception is ArgumentOutOfRangeException)
            {
                // For a 'not found' scenario, this is a better status code.
                statusCode = (int)HttpStatusCode.NotFound;
                title = "The requested resource was not found.";
            }
            // You can add more exception types here.
    
            // Return a standardized ProblemDetails response.
            return Results.Problem(
                title: title,
                statusCode: statusCode,
                detail: exception?.Message
            );
        });

        app.Run();
    }
}
