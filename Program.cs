using NotedApp.Api.Data;
using NotedApp.Api.Models.DTOs;
using NotedApp.Api.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// --- 1. REGISTER SERVICES ---

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// FORCE PORT BINDING: Render provides a $PORT environment variable
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
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

// Change this line in Program.cs
if (!app.Environment.IsDevelopment() && Environment.GetEnvironmentVariable("RENDER") != "true")
{
    app.UseHttpsRedirection();
}


app.UseHttpsRedirection();

// Middleware Order: Routing -> CORS -> Auth -> Endpoints
app.UseRouting();

app.UseCors("AllowVueApp");
app.UseAuthorization();
app.MapControllers();

// --- 3. FIX THE 404 ERROR ---
// Add a default route so the "Root" URL (/) returns a message instead of a 404
app.MapGet("/", () => "Noted API is running! Visit /swagger for documentation.");

app.Run();