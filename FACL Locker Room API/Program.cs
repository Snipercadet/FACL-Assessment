using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(q =>
    q.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "@FACL Locker Room API",
        Version = "v1",
        Description = "Code assessment submission",
        Contact = new OpenApiContact
        {
            Name = "Yakubu Abraham",
            Email = "donibris@gmail.com"
        }
    }));
    builder.Services.AddApiVersioning(q =>
    {
        var apiVersion = builder.Configuration.GetSection("ApiVersion:CurrentVersion").Value;
        q.ReportApiVersions = true;
        q.AssumeDefaultVersionWhenUnspecified = true;
        q.DefaultApiVersion = ApiVersion.Parse(apiVersion);
    });

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

    