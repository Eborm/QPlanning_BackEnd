using System;
using System.Linq;
using System.Threading.Tasks;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Common.Auth;

namespace QPlanning.Business.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository _userRepository;

        public AuthorizationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BaseResponse> CreateClaimRole(string email, string role)
        {
            var response = await _userRepository.CreateClaimRole(email, role);
            if (!UserRole.IsAllowedToRegisterRole(role))
                return new BaseResponse("-1", false, $"The following role: {role}. Cannot be registered.");
            
            if (response.Errors?.Any() != true) return new BaseResponse(response.Id, response.Success);
            var messages = response.Errors?.SelectMany(e => e?.Description);
            return new BaseResponse(response.Id, response.Success, string.Join(",", messages));

        }

        public async Task<BaseResponse> DeleteClaimRole(string email, string role)
        {
            var response = await _userRepository.DeleteClaimRole(email, role);
            if (!UserRole.IsAllowedToRegisterRole(role))
                return new BaseResponse("-1", false, $"The following role: {role}. Cannot be deleted.");
            
            if (response.Errors?.Any() != true) return new BaseResponse(response.Id, response.Success);
            var messages = response.Errors?.SelectMany(e => e?.Description);
            return new BaseResponse(response.Id, response.Success, string.Join(",", messages));
        }
    }
}