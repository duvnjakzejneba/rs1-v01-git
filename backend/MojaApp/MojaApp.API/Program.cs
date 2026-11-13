using Microsoft.EntityFrameworkCore;
using MojaApp.API.Controllers.Data;
using MojaApp.API.Controllers.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<StudentStorage>();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Main"))
);

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

StudentStorage._students.Add(new Student(){Id = 1, Ime = "Amer", Prezime = "Beso"});
StudentStorage._students.Add(new Student(){Id = 2, Ime = "Zejneba", Prezime = "Duvnjak-Beso"});

app.Run();