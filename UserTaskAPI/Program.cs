using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CabBooking.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adds DBContext, after this line it can be used in the repository or controller by simply adding a...
// UsersTasksContext parameter. A context object need not be created by the user.

// Context objects are used for Database interactions.
builder.Services.AddDbContext<CabBookingContext>(opt => opt.UseInMemoryDatabase("MyConnectionStr"));
builder.Services.AddMvc();
builder.Services.AddControllers();
//builder.Logging.AddConsole();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Note order of pipeline is important.
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
    
app.MapControllers();

app.Run();
