using hoopstatsapi.Application.Interfaces;
using hoopstatsapi.Application.Services;
using hoopstatsapi.Infrastructure.Data;
using hoopstatsapi.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using hoopstatsapi.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructureService();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
