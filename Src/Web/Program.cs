using Web;
using Infrastructure;
using Application;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.SeadData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.AddWebServiceCollection();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();
await app.AddWebConfigureService().ConfigureAwait(false);