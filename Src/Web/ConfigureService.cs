using Infrastructure.Context;
using Infrastructure.Persistence.SeadData;
using Microsoft.EntityFrameworkCore;

namespace Web;

public static class ConfigureService
{
    public static IServiceCollection AddWebServiceCollection(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
      
        return builder.Services;

    }
    public static async Task<IApplicationBuilder> AddWebConfigureService(this WebApplication app)
    {
        //get service
        var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        var context = services.GetRequiredService<ApplicationDbContext>();
        //Auto Migration
        try
        {
            await context.Database.MigrateAsync();
            await GenerateFakeData.SeedDataAsync(context, loggerFactory);
        }
        catch (Exception e)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(e, "Error exception fot migration");
        }


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

       await app.RunAsync();
        return app;

    }
}
