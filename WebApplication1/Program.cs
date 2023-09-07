using Car_pooling.Interfaces;

using Car_pooling.Repository;
using Microsoft.EntityFrameworkCore;
using Car_pooling.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarPoolingContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Mycon")));

builder.Services.AddScoped<IUserDetails, UserDetailsRepo>();
builder.Services.AddScoped<IPoolCreater, PoolCreaterRepo>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();

                      });
});//cors




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");//coars
app.UseAuthorization();

app.MapControllers();

app.Run();
