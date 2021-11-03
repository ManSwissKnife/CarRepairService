using Microsoft.EntityFrameworkCore;
using CarRepairService.Database;
using CarRepairService.Repositories;
using CarRepairService.Models;
using CarRepairService.Mappers.Interfaces;
using CarRepairService.Mappers.Implementations;
using CarRepairService.Services;
using CarRepairService.Models.DTO;
using CarRepairService.PatchRequestContractResolver;
using CarRepairService.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CRSContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new PatchRequestContractResolver();
});
builder.Services.AddTransient<IUserRepository, SQLUserRepository>();
builder.Services.AddTransient<IMapper<User, UserDTO>, UserMapper>();
builder.Services.AddTransient<IMapper<Product, ProductDTO>, ProductMapper>();
//builder.Services.AddTransient<IMapper<Document>, DocumentMapper>();
//builder.Services.AddTransient<IRepository<Document>, SQLRepository<Document>>();
builder.Services.AddTransient<IRepository<Product, ProductDTO>, SQLRepository<Product, ProductDTO>>();
builder.Services.AddTransient<IRepository<User, UserDTO>, SQLRepository<User, UserDTO>>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = AuthOptions.ISSUER,
                            ValidateAudience = true,
                            ValidAudience = AuthOptions.AUDIENCE,
                            ValidateLifetime = true,
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
