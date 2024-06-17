namespace Api.Features.Authentication;

[ExcludeFromCodeCoverage]
public class AuthenticationEndpoint(IConfiguration configuration) : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/authentication")
            .WithTags("Authentication");

        group.MapPost("/register", Register);
        group.MapPost("/login", Login);
    }

    /// <summary>
    /// Register a user
    /// </summary>

    public async Task<IResult> Register(IAuthenticationData authenticationData, RegisterEntity registerEntity, IValidator<RegisterEntity> validator)
    {
        var validationResult = await validator.ValidateAsync(registerEntity);

        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        var result = await authenticationData.RegisterUserAsync(registerEntity.Email, registerEntity.Password);

        if (result)
        {
            return Results.Ok("User created");
        }
        else
        {
            return Results.BadRequest();
        }
    }

    /// <summary>
    /// User login
    /// </summary>

    public async Task<IResult> Login(IAuthenticationData authenticationData, LoginEntity loginEntity, IValidator<LoginEntity> validator)
    {
        var validationResult = await validator.ValidateAsync(loginEntity);

        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        var result = await authenticationData.AuthenticateUserAsync(loginEntity.Email, loginEntity.Password);

        if (result)
        {
            var token = GenerateToken(loginEntity);
            return Results.Json(token);
        }
        else
        {
            return Results.Unauthorized();
        }
    }

    private UserToken GenerateToken(LoginEntity loginEntity)
    {
        var claims = new[]
        {
            new Claim("email", loginEntity.Email),
            new Claim("myvalue", "idkismyvalue"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(60);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
            audience: Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            claims: claims,
            signingCredentials: credentials,
            expires: expiration
        );

        return new UserToken()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}