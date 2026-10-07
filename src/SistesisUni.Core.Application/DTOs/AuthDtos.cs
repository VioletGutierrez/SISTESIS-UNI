namespace SistesisUni.Core.Application.DTOs
{
    public record LoginRequestDto(
        string Username,
        string Password
    );

    public record LoginResponseDto(
        string Token,
        string Username,
        DateTime ExpiresAt
    );
}