namespace Api.Features.Authentication;

public interface IAuthenticationData
{
    Task<bool> AuthenticateUserAsync(string email, string password);

    Task<bool> RegisterUserAsync(string email, string password);
}