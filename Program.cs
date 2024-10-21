using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieProjectWebAPI.Controllers;
using MovieProject.Data;
using Mapster;

using Microsoft.AspNetCore.Identity;
using MovieProjectWebAPI.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieContext>(options => options.UseSqlite(@"C:\Users\cupra\SE3\databasemovie.db"));

//Add services
builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<MovieContext>();
//Add controllers
builder.Services.AddScoped<MovieController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {

        c.DisplayOperationId();

    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();
app.MapGroup("identity").MapIdentityApi<User>();

app.UseAuthentication(); 
app.UseAuthorization(); 



app.Run();
