namespace GameCritic.Application.Common.Dtos.User;

public class UserTokenDto
{
    public long Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string Role { get; set; }

    public DateTime RegisterDateTime { get; set; }

    public string Token { get; set; }
}