using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Dto.Response.UseCase;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Authentication.Login.Dto.Response;
using QPlanning.Common.Auth;

namespace QPlanning.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly IMedewerkerRepository _medewerkerRepository;

        public AuthenticationService(IUserRepository userRepository, IJwtFactory jwtFactory, IMedewerkerRepository medewerkerRepository)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
            _medewerkerRepository = medewerkerRepository;
        }
        
        public async Task<BaseResponse> CreateUser(DomainModelUser domainModelUser, string password)
        {
           var response = await _userRepository.CreateUser(domainModelUser, password);
           if (response.Errors?.Any() != true)
           {
               //If the creation of the user is succeeded then also add the default role medewerker. 
               if (response.Success) await _userRepository.CreateClaimRole(domainModelUser.Email, UserRole.Medewerker);
               return new BaseResponse(response.Id, response.Success);
           }
           
           var messages = response.Errors?.SelectMany(e => e?.Description);
           return new BaseResponse(response.Id, response.Success, String.Join(",", messages));
        }
        
        public async Task<BaseResponse> UpdateUser(DomainModelUser domainModelUser)
        {
            var response = await _userRepository.UpdateUser(domainModelUser);
            if (response.Errors?.Any() != true) return new BaseResponse(response.Id, response.Success);
           
            var messages = response.Errors?.SelectMany(e => e?.Description);
            return new BaseResponse(response.Id, response.Success, String.Join(",", messages));
        }

        public async Task<BaseResponse> DeleteUser(string email)
        {
            var response = await _userRepository.DeleteUser(email);
            if (response.Errors?.Any() != true) return new BaseResponse(response.Id, response.Success);
           
            var messages = response.Errors?.SelectMany(e => e);
            return new BaseResponse(response.Id, response.Success, String.Join(",", messages));
        }

        public async Task<AllUserResponse> GetAllUsers()
        {
            var applicationUsers = await _userRepository.GetAllUsers();
            if (applicationUsers == null) throw new ArgumentNullException(nameof(applicationUsers));

            var detailedUserList = new List<DetailDomainModelUser>();
            foreach (var applicationUser in applicationUsers)
            {
                var detailedUser = new DetailDomainModelUser
                {
                    Achternaam = applicationUser.Achternaam,
                    Email = applicationUser.Email,
                    Id = applicationUser.Id,
                    Voornaam = applicationUser.Voornaam,
                    UserName = applicationUser.UserName,
                    PasswordHash = applicationUser.PasswordHash
                };
                
                var userRoles = await _userRepository.GetAllRolesForUser(applicationUser.Email);
                detailedUser.Roles = string.Join(", ", userRoles);
                
                detailedUserList.Add(detailedUser);
            }
            
            return new AllUserResponse { Users = detailedUserList};
        }

        public async Task<BaseResponse> ResetPassword(string email, string newPassword)
        {
            var result = await _userRepository.ResetPassword(email, newPassword);
            return result;
        }

        public async Task<LoginResponse> GenerateToken(string email, string password)
        {
            // confirm we have a user with the given name
            var user = await _userRepository.FindByEmail(email);
            var medewerker = _medewerkerRepository.GetDomainModelMedewerker(email);
            if (user != null && medewerker != null)
            {
                // validate password
                if (await _userRepository.CheckPassword(user, password))
                {
                    var roles = await _userRepository.GetAllRolesForUser(user.Email);
                    
                    // generate token
                    var token = await _jwtFactory.GenerateEncodedToken(user.Id, user.UserName, roles);
                    var loginResponse =
                        new LoginResponse {DomainModelUser = user, AuthToken = token.AuthToken, Success = true, HighestRole = GetHighestRole(roles)};
                    return loginResponse;
                }
            }
            
            var response = new LoginResponse{DomainModelUser = null, AuthToken = null, Success = false};
            return response;
        }

        private static string GetHighestRole(ICollection<string> roles) =>
            roles.Contains(UserRole.Admin) ? UserRole.Admin :
            roles.Contains(UserRole.Manager) ? UserRole.Manager :
            roles.Contains(UserRole.Planner) ? UserRole.Planner : UserRole.Medewerker;
    }
}