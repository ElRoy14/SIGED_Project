﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Siged.Application.Authentication.DTOs;
using Siged.Application.Authentication.Exceptions;
using Siged.Application.Authentication.Interfaces;
using Siged.Application.Authentication.Validators;
using Siged.Domain;
using Siged.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Siged.Application.Authentication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<UserInfo> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(IGenericRepository<UserInfo> userRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        private string GenerateToken(string UserId)
        {
            var key = _configuration.GetValue<string>("JwtSettings:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, UserId));

            var TokenCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
                );

            var DecryptionToken = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(15),
                SigningCredentials = TokenCredentials
            };

            var TokenHandler = new JwtSecurityTokenHandler();
            var TokenConfig = TokenHandler.CreateToken(DecryptionToken);

            string TokenCreated = TokenHandler.WriteToken(TokenConfig);

            return TokenCreated;

        }

        public async Task<LoginResponse> Login(string email, string password)
        {
            try
            {
                var loginRequest = new LoginRequest { Email = email, UserPassword = password };
                var loginRequestValidator = new LoginRequestValidator();
                var validationResult = loginRequestValidator.Validate(loginRequest);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException($"{string.Join(", ", errors)}");
                }

                var userQuery = await _userRepository.VerifyDataExistenceAsync(u => u.Email == email && u.UserPassword == password);
                var user = userQuery.FirstOrDefault() ?? throw new UserNotFoundException();

                UserInfo returnUser = userQuery.Include(rol => rol.Rol).First();
                //string token = GenerateToken(returnUser.UserId.ToString());

                var loginResponse = _mapper.Map<LoginResponse>(returnUser);
                //loginResponse.Token = token;

                return loginResponse;

            }
            catch
            {
                throw;
            }

        }

    }

}
