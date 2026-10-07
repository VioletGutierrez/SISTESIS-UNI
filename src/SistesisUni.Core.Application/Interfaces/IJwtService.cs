using SistesisUni.Core.Application.DTOs;

namespace SistesisUni.Core.Application.Interfaces
{
    public interface IJwtService
    {
        LoginResponseDto GenerateToken(string username);
    }
}