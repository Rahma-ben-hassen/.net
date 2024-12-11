using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Projet.BLL;
using Projet.BLL.Contract;
using Projet.Context;
using Projet.DAL;
using Projet.DAL.Contracts;
using Projet.DAL.Repos;
using Projet.Entities;
using Projet.Services;
using Projet.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Register DbContext with EnableRetryOnFailure to handle transient errors
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)) // Enable retry logic
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine));  // Log SQL queries to console (development only)

// Register repositories, UnitOfWork, services, etc.
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Client>, ClientRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped(typeof(IGenericBLL<>), typeof(GenericBLL<>));

// Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "User Management API", Version = "v1" });
});

var app = builder.Build();

// Enable CORS
app.UseCors("AllowAllOrigins");

// Enable Swagger middleware and UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Management API v1");
});

// Use Authorization and map controllers
app.UseAuthorization();
app.MapControllers();

app.Run();
