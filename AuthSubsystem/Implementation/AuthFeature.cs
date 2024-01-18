using AppRepository.UnitOfWork;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.AuthModels;
using Models.Entities;
using Models.ConfigModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AuthSubsystem.Implementation
{
    public class AuthFeature : IAuthFeature
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly JwtConfig _jwtConfig;
        public AuthFeature(IUnitOfWork unitOfWork, IMapper mapper, IOptions<JwtConfig> jwtConfig)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtConfig = jwtConfig.Value;
        }
        public string GenerateToken(TokenModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(CustomClaimTypes.Id, user.Id.ToString()),
                new Claim(CustomClaimTypes.Email,user.Email),
                new Claim(CustomClaimTypes.Role,user.Role.ToString()),                
                new Claim(CustomClaimTypes.Name, user.Name),
                new Claim(CustomClaimTypes.Avatar, user.Avatar)
            };
            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        /// <summary>
        /// <para>Throw KeyNotFoundException: Wrong credentials</para>
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        private async Task<TokenModel> LoginAsync(LoginRequestModel loginUser)
        {
            var user = await _unitOfWork.UserRepository.GetFirst(c => c.Email == loginUser.Email && c.Password == loginUser.Password);
            if(user == null)
            {
                throw new KeyNotFoundException("Record not found!");
            }
            if(user.RoleId == (int)Models.Enum.Role.Customer)
            {
                var customer = await _unitOfWork.CustomerRepository.GetFirst(c => c.User.Email == loginUser.Email, nameof(Customer.User));
                if(customer == null)
                {
                    //create new customer by userId
                    var customerAdd = new CustomerAddModel
                    {
                        UserId = user.Id,                        
                    };
                    customer = _mapper.Map<Customer>(customerAdd);
                    await _unitOfWork.CustomerRepository.Add(customer);
                    customer.User = user;
                }
                var tokenizedData = _mapper.Map<TokenModel>(customer);
                return tokenizedData;
            } else if(user.RoleId == (int)Models.Enum.Role.Trainer)
            {
                var trainer = await _unitOfWork.TrainerRepository.GetFirst(c => c.User.Email == loginUser.Email, nameof(Trainer.User));
                if (trainer == null)
                {
                    //create new customer by userId
                    var trainerAdd = new TrainerAddModel
                    {
                        UserId = user.Id,
                    };
                    trainer = _mapper.Map<Trainer>(trainerAdd);
                    await _unitOfWork.TrainerRepository.Add(trainer);
                    trainer.User = user;
                }
                var tokenizedData = _mapper.Map<TokenModel>(trainer);
                return tokenizedData;
            } else
            {
                var tokenizedData = _mapper.Map<TokenModel>(user);
                return tokenizedData;
            }
        }
        /// <summary>
        /// <para>Throw KeyNotFoundException: Wrong credentials</para>
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public async Task<string> Login(LoginRequestModel loginUser)
        {
            var tokenModel = await LoginAsync(loginUser);
            var token = GenerateToken(tokenModel);
            return token;
        }
        /// <summary>
        /// Register a new customer account
        /// <para>Throw InvalidOperationException: Duplicated email</para>
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<string> Register(RegisterRequestModel registerUser)
        {
            //check duplicate email
            var check = await _unitOfWork.UserRepository.GetFirst(c => c.Email == registerUser.Email || c.PhoneNumber == Decimal.Parse(registerUser.PhoneNumber));
            if(check != null)
            {
                throw new InvalidOperationException("Existing email or phone number!");
            }
            //add user and customer record
            var user = _mapper.Map<User>(registerUser);
            await _unitOfWork.UserRepository.Add(user);
            var customerAdd = new CustomerAddModel
            {
                UserId = user.Id,
            };
            var customer = _mapper.Map<Customer>(customerAdd);
            await _unitOfWork.CustomerRepository.Add(customer);
            customer.User = user;
            //generate token
            var tokenizedData = _mapper.Map<TokenModel>(customer);
            var token = GenerateToken(tokenizedData);
            return token;
        }

        public List<Claim> DeserializedToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(accessToken) as JwtSecurityToken;
            return jsonToken.Claims.ToList();
        }

        public async Task<TokenModel?> ValidateToken(string? token)
        {
            if(token == null)
            {
                return null;
            }
            token = token.Split(" ")[1];
            if(token == null || token.Length == 0)
            {
                return null;
            }
            var claims = DeserializedToken(token);
            var email = claims.First(c => c.Type == CustomClaimTypes.Email).Value;
            var user = await _unitOfWork.UserRepository.GetFirst(c => c.Email == email);
            return _mapper.Map<TokenModel>(user);
        }
    }
}
