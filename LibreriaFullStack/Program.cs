using Libreria.Backend.Data;
using Libreria.Backend.Repository;
using Libreria.Backend.RepositoryImpl;
using Libreria.Backend.Service;
using Libreria.Backend.ServiceImpl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext <LibreriaContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//inyeccion de dependencia
builder.Services.AddScoped<IServiceLibro, ServiceLibroImpl>();
builder.Services.AddScoped<IRepositoryLibro, RepositoryLibroImpl>();

builder.Services.AddScoped<IServiceAutor, ServiceAutorImpl>();
builder.Services.AddScoped<IRepositoryAutor, RepositoryAutorImpl>();


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
