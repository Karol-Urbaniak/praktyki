using Microsoft.EntityFrameworkCore;
using praktyki.Commands;
using praktyki.Data;
using praktyki.Models;
using praktyki.Repositories;
using praktyki.Services;



var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Defaultconnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<VerifyPeselCommand>();
builder.Services.AddScoped<VerifyPeselService>();
builder.Services.AddHttpClient<ViesService>();
builder.Services.AddHttpClient<WeatherService>();
builder.Services.Configure<praktyki.Models.WeatherSettings>(builder.Configuration.GetSection("WeatherSettings"));



var app = builder.Build();

if (app.HandleConsoleCommand(args)) return;

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
