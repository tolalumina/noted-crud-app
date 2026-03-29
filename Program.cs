using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/product", async (HttpClient httpClient) =>
{
     var respone = await httpClient.GetAsync("https://api.escuelajs.co/api/v1/products");

    if (respone.StatusCode == System.Net.HttpStatusCode.OK)
    { 
        var data = await respone.Content.ReadAsStringAsync();
        return Results.Ok(data);
    }
    else
    {
       return Results.BadRequest("Faild to load Products");
    }
   
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
