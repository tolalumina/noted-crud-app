using Dapper;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from appsettings.json
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var app = builder.Build();

app.MapGet("/", () =>
{
    using var connection = new SqlConnection(connectionString);
    connection.Open();

    // Example: select all students
    var students = connection.Query<Student>("SELECT Id, StudentName FROM Students");

    return students;
});

app.Run();

// Student model
public record Student(int Id, string StudentName);





using Dapper;
using NotedApp.Api.Models.Entities;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ FIXED: Get connection string INSIDE endpoint
app.MapGet("/notes", (IConfiguration config) =>
{
    var connectionString = config.GetConnectionString("DefaultConnection");

    Console.WriteLine("Connection String: " + connectionString);

    using var connection = new SqlConnection(connectionString);
    connection.Open();

    var notes = connection.Query<Note>(
        "SELECT * FROM Notes ORDER BY CreatedAt DESC"
    );

    return Results.Ok(notes);
});

app.Run();