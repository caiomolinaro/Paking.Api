namespace Api.Features.Authentication;

[ExcludeFromCodeCoverage]
public class AuthenticationData : IAuthenticationData
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthenticationData(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> RegisterUserAsync(string email, string password)
    {
        var applicationUser = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(applicationUser, password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(applicationUser, isPersistent: false);
        }
        return result.Succeeded;
    }

    public async Task<bool> AuthenticateUserAsync(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

        return result.Succeeded;
    }
}