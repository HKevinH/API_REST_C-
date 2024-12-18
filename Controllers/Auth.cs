
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    // private readonly 

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request.Username == "admin" && request.Password == "admin")
        {
            var token = GenerateJwtToken(request.Username);
            return Ok(new { token });
        }

        return Unauthorized();
    }

    [HttpPost("generate-token")]
    public String GenerateJwtToken(string username)
    {
        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("S3cur3K3yTh@tIsAtLeast32CharsLong!"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
            issuer: "emisor-id",
            audience: "audiencia-id",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


    [HttpGet("secure-data")]
    [Authorize]

    public IActionResult GetSecureData()
    {
        //This Claims JWT Valid
        return Ok(new { message = "Route Protect" });
    }

    [HttpGet("admin-data")]
    [Authorize(Roles = "admin")]
    public IActionResult GetAdminData()
    {
        return Ok(new { secretIndo = "Data For Admins" });
    }


    [HttpGet("profile")]
    [Authorize]
    public IActionResult GetUserInfo()
    {
        var username = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
        return Ok(new { username = username, message = "Info" });
    }


    [HttpPost("refresh-token")]
    public IActionResult RefreshToken([FromBody] RefreshRequest refreshRequest)
    {

        var newToken = GenerateJwtToken("usernew");
        return Ok(new { token = newToken });
    }
}

public class RefreshRequest
{
    public string? RefreshToken { get; set; }
}

public class LoginRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}