using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
