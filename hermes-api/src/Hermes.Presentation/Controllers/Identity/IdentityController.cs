public static class IdentityController 
{

    public static void MapIdentityRoutes(this IEndpointRouteBuilder app) 
    {
        app.MapPost("/login", async (UserPlainCredentialsDTO plainCredentials, IdentityHandler identityHandler) => 
        {
            if (await identityHandler.HandleLoginAsync(plainCredentials))
            {
                return Results.Ok("Login successful");
            }
            return Results.Unauthorized();
        })
        .Produces<string>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status401Unauthorized)
        .WithName("Login")
        .WithTags("Authentication");


        app.MapPost("/register", async (UserPlainCredentialsDTO plainCredentials, IdentityHandler identityHandler) => 
        {
            await identityHandler.HandleRegisterAsync(plainCredentials.Username, plainCredentials.Password);
            
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


