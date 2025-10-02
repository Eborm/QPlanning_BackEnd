using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities.Logging;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.Interfaces.Repositories.Gateway
{
    public interface ILogRepository
    {
        Task<BaseResponse> AddExceptionLog(DomainModelExceptionLog domainModelExceptionLog);
        Task<BaseResponse> AddCustomLog(DomainModelCustomLog exceptionLog);
    }
}