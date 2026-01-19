public static class AuthEndpoints 
{

    public static void MapAuthRoutes(this IEndpointRouteBuilder app) 
    {
        app.MapPost("/login", async (LoginRequest credentials, AuthService authService) => 
        {
            if (await authService.AuthenticateAsync(credentials))
            {
                return Results.Ok("Login successful");
            }
            return Results.Unauthorized();
        })
        .Produces<string>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status401Unauthorized)
        .WithName("Login")
        .WithTags("Authentication");


        app.MapPost("/register", async (LoginRequest request, AuthService authService) => 
        {
            await authService.RegisterAsync(request.username, request.password);
            
            return Results.Created($"/users/{request.username}", null);
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


