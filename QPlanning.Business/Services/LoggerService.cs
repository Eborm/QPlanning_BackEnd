using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities.Logging;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogRepository _logRepository;

        public LoggerService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<BaseResponse> PersistException(DomainModelExceptionLog domainModelExceptionLog)
        {
           var response = await _logRepository.AddExceptionLog(domainModelExceptionLog);
           return response;
        }

        public async Task<BaseResponse> PersistLogging(DomainModelCustomLog domainModelCustomLog)
        {
            var response = await _logRepository.AddCustomLog(domainModelCustomLog);
            return response;
        }
    }
}