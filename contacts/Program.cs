using contacts;
using contacts.Application.Context;
using contacts.Repository;
using contacts.Repository.Impl;
using contacts.Services;
using contacts.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IContactService, ContactServiceImpl>();
builder.Services.AddScoped<IContactRepository, ContactRepositoryImpl>();
builder.Services.AddScoped<IZipCodeService, ZipCodeServiceImpl>();
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("test"));

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

app.UseCors();

app.Run();