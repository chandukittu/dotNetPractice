using Coravel;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using Practice.Interfaces;
using Practice.Services;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");
var config = configuration.Build();
builder.Configuration.AddConfiguration(config);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScheduler();
string dbConnectionString = config.GetConnectionString("OracleConnection");
builder.Services.AddTransient<IDbConnection>((sp) => new OracleConnection(dbConnectionString));
builder.Services.AddTransient<ICustomer, Customer>();
builder.Services.AddTransient<IPackageCustomer, PackageCustomer>();
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
