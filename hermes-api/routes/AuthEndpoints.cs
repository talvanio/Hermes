public static class AuthEndpoints 
{
    private static string uncriptPassword(string encryptedPassword)
    {
        return encryptedPassword; // TODO: implement decryption
    }

    private static bool validateCredentials(LoginRequest credentials)
    {
        return true;  // TODO: implement validation
    }

    public static void MapAuthRoutes(this IEndpointRouteBuilder app) 
    {
        app.MapPost("/login", (LoginRequest credentials) => 
        {
            string? password = uncriptPassword(credentials.password);
            LoginRequest decryptedCredentials = new LoginRequest{username = credentials.username, password = password};
            if (validateCredentials(decryptedCredentials))
            {
                return Results.Ok("jwt placeholder"); // TODO: jwt token generation
            }
            else
            {
                return Results.Unauthorized();
            
            }

        })
        .Produces<string>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status401Unauthorized)
        .WithName("Login")
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


