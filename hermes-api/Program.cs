using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapAuthRoutes();
app.UseHttpsRedirection();
app.Run();

public record LoginRequest
{
    public required string username { get; init; }
    public required string password { get; init; }
}