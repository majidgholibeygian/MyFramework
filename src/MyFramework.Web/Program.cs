// src/MyFramework.Web/Program.cs
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFramework.Application;
using MyFramework.Infrastructure.DependencyInjection;
using MyFramework.Infrastructure.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", p => p
    .WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());
});

// configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("MyFramework.Application")));

// controllers
builder.Services.AddControllers().AddNewtonsoftJson();

// swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureKestrel(options =>
{
    // increase max request body size to 1 GB
    options.Limits.MaxRequestBodySize = 1_073_741_824; // bytes
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 1_073_741_824; // 1 GB
});

var app = builder.Build();

// ensure database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyFrameworkDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();


app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();