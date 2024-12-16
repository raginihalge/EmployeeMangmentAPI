using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;

    public TokenValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Get the Authorization header
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");

        if (!string.IsNullOrEmpty(token))
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                if (tokenHandler.CanReadToken(token))
                {
                    var jwtToken = tokenHandler.ReadJwtToken(token);

                    // Check expiration claim (exp)
                    var expClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;
                    if (expClaim != null)
                    {
                        var expiryDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expClaim)).UtcDateTime;

                        // Check if the token is expired
                        if (expiryDate < DateTime.UtcNow)
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            await context.Response.WriteAsync("Token has expired.");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle invalid token
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync($"Invalid token: {ex.Message}");
                return;
            }
        }

        // Call the next middleware in the pipeline
        await _next(context);
    }
}
