using Infrastructure_Layer.Caching;
using Infrastructure_Layer.Data;
using Domain_Layer.Entities;
using Infrastructure_Layer.Repositories;
using Application_Layer.Services;
using Application_Layer.Interfaces;
using Domain_Layer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

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

//cross-origin policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowLocalHost",
                      policy =>
                      {
                          policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowLocalHost");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
