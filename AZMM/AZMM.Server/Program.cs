using Froghopper.Context;
using Microsoft.EntityFrameworkCore;

Directory.SetCurrentDirectory(AppContext.BaseDirectory);

var options = new WebApplicationOptions
{
    Args = args,
};

var builder = WebApplication.CreateBuilder(options);



builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var context = new AzmmDbContext())
{
    context.Database.Migrate();
}

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
