using DataLayer.HealthCare.DataModels;
using DataLayer.HealthCare.Repositories;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//*************** Start database connection *************//
builder.Services.AddDbContext<ComfortHealthContext>(options =>
        options.UseSqlServer(builder.Configuration["Connnectionstrings:Connection"]));
builder.Services.AddScoped<EfCoreDoctorRepository>();
builder.Services.AddScoped<EfCorePatientRepository>();
builder.Services.AddScoped<EfCorePatientHistoryRepository>();
//*************** End database connection *************//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
        c.DisplayOperationId();
        c.DocExpansion(DocExpansion.None);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
