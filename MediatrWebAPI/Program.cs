using DataStore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

RegisterServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void RegisterServices(WebApplicationBuilder builder)
{
    //--- register the DbContext on the container, getting the connection string from
    //--- appSettings (note: use this during development; in a production environment,
    //--- it's better to store the connection string in an environment variable)

    //var connectionString = Configuration["ConnectionStrings:NorthwindConnStr"];
    var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:NorthwindConnStr")?.Replace(@"\\", @"\");
    if (!string.IsNullOrWhiteSpace(connectionString))
        builder.Services.AddDbContext<NorthwindContext>(o => o.UseSqlServer(connectionString));

    builder.Services.AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    });
}