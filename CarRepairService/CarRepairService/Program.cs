using Microsoft.EntityFrameworkCore;
using CarRepairService.DataBase;
using CarRepairService.Repositories.Interfaces;
using CarRepairService.Models;
using CarRepairService.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CRSContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllers();
builder.Services.AddScoped<IRepository<Document>, SQLRepository<Document>>();
builder.Services.AddScoped<IRepository<Car>, SQLRepository<Car>>();
builder.Services.AddScoped<IRepository<Worker>, SQLRepository<Worker>>();
var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
