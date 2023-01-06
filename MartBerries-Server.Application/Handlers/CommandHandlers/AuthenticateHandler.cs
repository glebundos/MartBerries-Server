using MartBerries_Server.Application.Commands;
using MartBerries_Server.Application.Helpers;
using MartBerries_Server.Application.Models;
using MartBerries_Server.Core.Entities;
using MartBerries_Server.Core.Repositories;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Application.Handlers.CommandHandlers
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateCommand, AuthenticateResponse>
    {
        private readonly IUserRepository _userRepo;

        private readonly string _secret = "mysecretmysecretmysecretmysecretmysecretmysecretmysecretmysecretmysecretmysecretmysecret";

        public AuthenticateHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<AuthenticateResponse> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepo.GetByCreds(request.Username, request.Password);
                if (user == null)
                {
                    return null!;
                }

                var token = generateJwtToken(user);

                return new AuthenticateResponse(user, token);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;

        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 20 seconds
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddSeconds(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
