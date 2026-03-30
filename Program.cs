using NotedApp.Api.Data;
using NotedApp.Api.Models.DTOs;
using NotedApp.Api.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// --- 1. REGISTER SERVICES ---

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// 1. Dynamic Port Binding
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
builder.WebHost.UseUrls($"http://*:{port}");
// Database Context
builder.Services.AddSingleton<NotedDbContext>();

// CORS Configuration (Must be registered before builder.Build())
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") 
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// --- 2. CONFIGURE HTTP PIPELINE ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Middleware Order: Routing -> CORS -> Auth -> Endpoints
app.UseRouting();

app.UseCors("AllowVueApp");

app.UseAuthorization();

app.MapControllers();

app.Run();