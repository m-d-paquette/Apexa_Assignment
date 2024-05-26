using Apexa_API.Caching;
using Apexa_API.Data;
using Apexa_API.Models;
using Apexa_API.Repositories;
using Apexa_API.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// register services
builder.Services.AddScoped<IAdvisorService, AdvisorService>();

// register repositories
builder.Services.AddScoped<IAdvisorRepository, AdvisorRepository>();

// register MRU cache
builder.Services.AddSingleton<MruCache<int, Advisor>>(provider => new MruCache<int, Advisor>());

// Add In Memory database
builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
