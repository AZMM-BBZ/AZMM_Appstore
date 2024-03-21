using Froghopper.Context;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

Directory.SetCurrentDirectory(AppContext.BaseDirectory);

var options = new WebApplicationOptions
{
    Args = args,
};

var builder = WebApplication.CreateBuilder(options);

// Add services to the container.

builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var context = new AzmmDbContext())
{
    context.Database.Migrate();
}

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
