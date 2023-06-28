using DemoStore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.Development.json") // Example: JSON configuration file
    .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EFDbContext>(optBuilder => optBuilder.UseSqlServer(configuration.GetConnectionString("DemoStoreDb"))
             // .UseLoggerFactory(loggerFactory)
              .EnableSensitiveDataLogging());
builder.Services.AddTransient<IProductRepo, ProductRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    Console.WriteLine("--------====================================---------");
    Console.WriteLine(DateTime.Now.ToString() + " : " + new Random().Next());
    Console.WriteLine("--------====================================---------");
}

//app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();
app.Run();
