using actividadPractica3.Models;
using actividadPractica3.Data;
using actividadPractica3.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext < AplicationContext > (options => options.UseSqlServer(connString));
builder.Services.AddScoped<IAplication, AplicationService>();
builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<AplicationService, AplicationService>();
builder.Services.AddScoped<AplicationContext, AplicationContext>();
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
