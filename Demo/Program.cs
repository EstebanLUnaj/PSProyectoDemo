using Aplication.Interfaces;
using Aplication.UseCase.Students;
using Aplication.UseCase.Students.GetAll;
using Infraestructura.Command;
using Infraestructura.Persistence;
using Infraestructura.Querys;
using Microsoft.EntityFrameworkCore;
using System;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IStudentServices, StudentServices>();
builder.Services.AddScoped<IStudentQuery, StudentQuery>();
builder.Services.AddScoped<IStudentsCommand, StudentsCommand>();
//cambia de nombre a AppDbContext
builder.Services.AddTransient<IServicesGetAll, ServicesGetAll>();



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
