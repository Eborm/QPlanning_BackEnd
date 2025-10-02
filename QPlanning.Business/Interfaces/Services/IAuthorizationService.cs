using System.Threading.Tasks;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.Interfaces.Services
{
    public interface IAuthorizationService
    {
        Task<BaseResponse> CreateClaimRole(string email, string role);
        
        Task<BaseResponse> DeleteClaimRole(string email, string role);
    }
}