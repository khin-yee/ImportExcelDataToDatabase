

using Excel_PostgreDB.Domain.IRepository;
using Excel_PostgreDB.Domain.IService;
using Excel_PostgreDB.Repository;
using Excel_PostgreDB.Service;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseConnect>(options => {
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IService,Service>();
builder.Services.AddScoped<IRepository,Repository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
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
