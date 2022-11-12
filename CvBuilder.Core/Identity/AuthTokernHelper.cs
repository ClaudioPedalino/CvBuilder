namespace CvBuilder.Core.Identity
{
    public class AuthTokernHelper : IAuthTokernHelper
    {
        private readonly JwtSettings _jwtSettings;

        public AuthTokernHelper(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public AuthenticationResult GenerateAuthResult(IdentityUser newUser) // TODO: Esto se puede llevar a un servicio aparte para que la clase quede más chica
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.UtcNow.ToString("d")),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
