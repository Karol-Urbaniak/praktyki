using Microsoft.EntityFrameworkCore;
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
builder.Services.AddHttpClient<praktyki.Services.ViesService>();
builder.Services.AddScoped<praktyki.Services.VerifyPeselService>();
builder.Services.AddHttpClient<WeatherService>();
builder.Services.Configure<praktyki.Models.WeatherSettings>(
builder.Configuration.GetSection("WeatherSettings"));


var app = builder.Build();

if (args.Length > 0 && args[0] == "--verify-pesel")
{
    if (args.Length < 2)
    {
        Console.WriteLine("Błąd: Podaj PESEL");
        return;
    }

    string pesel = args[1];

    using (var scope = app.Services.CreateScope())
    {
        var peselService = scope.ServiceProvider.GetRequiredService<VerifyPeselService>();

        bool isCheckSumOk = peselService.VerifyCheckSum(pesel);


        if (isCheckSumOk)
        {
            var data = peselService.GetPeselData(pesel);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"PESEL: {pesel} jest POPRAWNY.");
            Console.WriteLine($"Data urodzenia: {data.BirthDate}");
            Console.WriteLine($"Płeć: {data.Gender}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"PESEL: {pesel} jest BŁĘDNY - suma kontrolna się nie zgadza");
        }
        Console.ResetColor();
    }
    return;
}

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
