using Microsoft.EntityFrameworkCore;
using SystemVentas.Infrastructure.Context;
using SystemVentas.Infrastructure.Interfaces;
using SystemVentas.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

//*== Add services to the container. ==*//

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//*== Registro dependencia BD ==*//
builder.Services.AddDbContext<SystemVentasContext>(option => 
option.UseSqlServer(builder.Configuration.GetConnectionString("SystemVentasContext")));

//*== Registro de Repositorios ==*//
builder.Services.AddTransient<ICategoriaRepository, CategoriasRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
