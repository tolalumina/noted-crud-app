using NotedApp.Api.Data;
using NotedApp.Api.Models.DTOs;
using NotedApp.Api.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// --- 1. REGISTER SERVICES ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dynamic Port Binding for Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
builder.WebHost.UseUrls($"http://*:{port}");

// Database Context - Ensure this reads the Env Var "ConnectionStrings__DefaultConnection"
builder.Services.AddSingleton<NotedDbContext>();

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://your-vue-app.onrender.com") 
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// --- 2. CONFIGURE HTTP PIPELINE ---

// REMOVE the 'if (app.Environment.IsDevelopment())' check so Swagger works on Render
app.UseSwagger();
app.UseSwaggerUI(options => {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty; // This makes Swagger the Home Page (Fixes 404)
});

// Render handles HTTPS at the load balancer; .NET doesn't need to redirect it
// app.UseHttpsRedirection(); 

app.UseRouting();
app.UseCors("AllowVueApp");
app.UseAuthorization();

// Add a simple health check route
app.MapGet("/health", () => Results.Ok("API is healthy"));

app.MapControllers();

app.Run();