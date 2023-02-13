using Base.data.Services;
using Microsoft.EntityFrameworkCore;
using Base.data.Models;
using Microsoft.Extensions.DependencyInjection;
using Base.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDBContext")));
//var service = new FakeTodoService();
//var context = new ApplicationDBContext();
//var todo = new TodoItemController(context, service);

builder.Services.AddScoped<ITodoInterface, TodoService>();


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

