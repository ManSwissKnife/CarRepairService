using Microsoft.EntityFrameworkCore;
using CarRepairService.DataBase;
using CarRepairService.Repositories.Interfaces;
using CarRepairService.Models;
using CarRepairService.Repositories.Implementations;
using CarRepairService.Mappers;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CRSContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllers();
builder.Services.AddTransient<IMapper<Worker>, WorkerMapper>();
builder.Services.AddTransient<IMapper<Car>, CarMapper>();
builder.Services.AddTransient<IMapper<Document>, DocumentMapper>();
builder.Services.AddTransient<IRepository<Document>, SQLRepository<Document>>();
builder.Services.AddTransient<IRepository<Car>, SQLRepository<Car>>();
builder.Services.AddTransient<IRepository<Worker>, SQLRepository<Worker>>();
var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
