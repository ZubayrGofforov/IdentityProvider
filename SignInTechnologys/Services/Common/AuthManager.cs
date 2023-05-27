using Microsoft.IdentityModel.Tokens;
using SignInTechnologys.Interfaces.Common;
using SignInTechnologys.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SignInTechnologys.Services.Common
{
	public class AuthManager : IAuthManager
	{
		private readonly IConfiguration _config;
		public AuthManager(IConfiguration configuration)
		{
			this._config = configuration;
		}

		public string GenerateToken(User user)
		{
			var claims = new[]
			{
				new Claim("Id", user.Id.ToString()),
				new Claim("FirstName", user.FirstName),
				new Claim("LastName", user.LastName),
				new Claim(ClaimTypes.Email, user.Email),
			};

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

			var tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
				expires: DateTime.Now.AddMinutes(double.Parse(_config["Lifetime"])),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
		}
	}
}
