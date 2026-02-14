using AdvancedDevSample.Api.Middlewares;
using AdvancedDevSample.Application.services;
using AdvancedDevSample.Domain.Interfaces;
using AdvancedDevSample.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;

    foreach (var xmlFile in Directory.GetFiles(basePath, "*.xml")) { 
        options.IncludeXmlComments(xmlFile);
    }
});

// =============Dependances Application ===================
builder.Services.AddScoped<IProductRepository, EfProductRepository>();

// =============Dependances Infrastructure ===================
builder.Services.AddScoped<ProductService>();

builder.Services.AddControllers();


// Ajouter la politique CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandLingMiddleware>();

// Activer CORS 
app.UseCors("MyAllowSpecificOrigins");

app.MapControllers();

app.Run();
