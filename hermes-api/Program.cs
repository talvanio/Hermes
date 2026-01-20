using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration.GetValue<string>("AllowedOrigins") ?? "http://localhost:3000";

builder.Services.AddCors(options =>
{
    options.AddPolicy("HermesFrontPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.InjectMongoDatabase(builder.Configuration);
builder.Services.AddScoped<IUserRepository, MongoUserRepository>();
builder.Services.AddScoped<IdentityHandler>();

builder.Services.AddOpenApi();

var app = builder.Build();
app.UseCors("HermesFrontPolicy");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapIdentityRoutes();
app.UseHttpsRedirection();
app.Run();
