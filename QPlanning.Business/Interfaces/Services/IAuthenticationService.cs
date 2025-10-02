using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Dto.Response.UseCase;
using QPlanning.Business.UseCases.Authentication.Login.Dto.Response;

namespace QPlanning.Business.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<BaseResponse> CreateUser(DomainModelUser domainModelUser, string password);
        
        Task<BaseResponse> UpdateUser(DomainModelUser domainModelUser);
        Task<BaseResponse> DeleteUser(string email);
        Task<AllUserResponse> GetAllUsers();
        Task<BaseResponse> ResetPassword(string email, string newPassword);
        Task<LoginResponse> GenerateToken(string email, string password);
    }
}