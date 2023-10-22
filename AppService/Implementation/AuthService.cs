using AppRepository.UnitOfWork;
using AuthSubsystem;
using AuthSubsystem.Implementation;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Options;
using Models.AuthModels;
using Models.ConfigModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Implementation
{
    public class AuthService : AuthFeature, IAuthService
    {
        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, IOptions<JwtConfig> jwtConfig) : base(unitOfWork, mapper, jwtConfig)
        {
        }
    }
}
