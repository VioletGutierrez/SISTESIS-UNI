using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistesisUni.Core.Application.DTOs;
using SistesisUni.Core.Application.Interfaces;

namespace SistesisUni.Api.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService) => _jwtService = jwtService;

        /// <summary>
        /// Login simplificado para demo. En producción validar contra BD/UNI.
        /// </summary>
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            // DEMO: acepta cualquier usuario con password "uni2026"
            // TODO: validar contra SIAT UNI o tabla de usuarios
            if (string.IsNullOrWhiteSpace(request.Username) || request.Password != "uni2026")
            {
                return Unauthorized(new { message = "Credenciales inválidas" });
            }

            var response = _jwtService.GenerateToken(request.Username);
            return Ok(response);
        }
    }
}