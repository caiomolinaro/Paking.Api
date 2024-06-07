using Api.Features.Authentication.Identity;

namespace UnitTests.Features.Authentication;

public class UserTokenUnitTest
{
    [Fact(DisplayName = "Should Create a User Token With Valid State")]
    public void Should_Create_a_User_Token_With_Valid_State()

    {
        // Arrange
        string token = "randomtoken123";
        DateTime expiration = DateTime.UtcNow;

        // Act
        var userToken = new UserToken
        {
            Token = token,
            Expiration = expiration,
        };
        // Assert
        userToken.Token.Should().Be(token);
        userToken.Expiration.Should().Be(expiration);
    }
}