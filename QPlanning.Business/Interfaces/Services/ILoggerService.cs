using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities.Logging;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.Interfaces.Services
{
    public interface ILoggerService
    {
        Task<BaseResponse> PersistException(DomainModelExceptionLog domainModelExceptionLog);
        Task<BaseResponse> PersistLogging(DomainModelCustomLog domainModelCustomLog);
    }
}