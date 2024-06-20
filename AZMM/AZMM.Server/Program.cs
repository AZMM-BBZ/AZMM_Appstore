using AZMM.Server.Services;
using AZMM.Server.Services.Interfaces;
using Froghopper.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

Directory.SetCurrentDirectory(AppContext.BaseDirectory);

var options = new WebApplicationOptions
{
    Args = args,
};

var builder = WebApplication.CreateBuilder(options);

//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer("Bearer", options =>
//    {
//        var issuer = builder.Configuration["Authentication:Issuer"];
//        var audience = builder.Configuration["Authentication:Audience"];
//        var secret = builder.Configuration["Authentication:SecretForKey"];

//        if (issuer == null || audience == null || secret == null)
//        {
//            throw new InvalidOperationException("Authentication configuration values cannot be null.");
//        }

//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = issuer,
//            ValidAudience = audience,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret))
//        };
//    });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var issuer = builder.Configuration["Authentication:Issuer"];
    var audience = builder.Configuration["Authentication:Audience"];
    var secret = builder.Configuration["Authentication:SecretForKey"];

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret))
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});


builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<AzmmDbContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAppService, AppService>();
builder.Services.AddHttpContextAccessor();

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

app.UseCors("AllowAllOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
