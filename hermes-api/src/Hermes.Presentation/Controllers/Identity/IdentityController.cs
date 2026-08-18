using hermes_api.Hermes.Application;
using hermes_api.Hermes.Application.Identity;

namespace hermes_api.Hermes.Presentation.Controllers.Identity;

public static class IdentityController 
{

    public static void MapIdentityRoutes(this IEndpointRouteBuilder app) 
    {
        app.MapPost("/login", async (LoginPlainCredentialsDto loginCredentials, IdentityHandler identityHandler) => 
            {
                if (await identityHandler.HandleLoginAsync(loginCredentials))
                {
                    return Results.Ok("Login successful");
                }
                return Results.Unauthorized();
            })
            .Produces<string>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithName("Login")
            .WithTags("Authentication");


        app.MapPost("/register", async (RegisterPlainCredentialsDto plainCredentials, IdentityHandler identityHandler) => 
            {
                await identityHandler.HandleRegisterAsync(plainCredentials);
                return Results.Created($"/users/{plainCredentials.Username}", null);
            })
            .Produces(StatusCodes.Status201Created)
            .WithName("Register")
            .WithTags("Authentication");

        app.MapGet("/logout", () =>
            {
                return;
            })
            .Produces(StatusCodes.Status200OK)
            .WithName("Logout")
            .WithTags("Authentication");
    }
}