using Microsoft.EntityFrameworkCore;
using TestForDiss.Data;
using Microsoft.Extensions.DependencyInjection;
using webapi.Controllers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<MyDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("MyConnectionString")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();

app.UseRouting();

app.MapRegionsEndpoints();

app.MapCountriesEndpoints();

app.MapPlantsEndpoints();



app.Run();