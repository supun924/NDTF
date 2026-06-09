using MediatR;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Auth.Commands
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepo;
        private readonly IPasswordHasher _hasher;
        private readonly IJwtTokenService _jwt;

        public LoginHandler(
            IUserRepository userRepo,
            IPasswordHasher hasher,
            IJwtTokenService jwt)
        {
            _userRepo = userRepo;
            _hasher = hasher;
            _jwt = jwt;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetByUsernameAsync(request.Username);

            if (user == null)
                throw new Exception("Invalid username or password");

            if (!_hasher.Verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid username or password");

            return _jwt.GenerateToken(user);
        }
    }
}
