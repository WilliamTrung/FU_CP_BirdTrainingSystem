using Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthSubsystem
{
    public interface IAuthFeature
    {
        /// <summary>
        /// <para>Throw KeyNotFoundException: Wrong credentials</para>
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        Task<string> Login(LoginRequestModel loginUser);
        /// <summary>
        /// Register a new customer account
        /// <para>Throw InvalidOperationException: Duplicated email</para>
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<string> Register(RegisterRequestModel registerUser);
        List<Claim> DeserializedToken(string accessToken);
    }
}
