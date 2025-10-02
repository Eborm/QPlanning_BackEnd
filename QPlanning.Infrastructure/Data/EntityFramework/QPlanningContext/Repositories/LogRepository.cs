using System.Threading.Tasks;
using AutoMapper;
using QPlanning.Business.Domain.Entities.Logging;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Repositories.Gateway;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly QPlanningApplicationContext _qPlanningContext;
        private readonly IMapper _mapper;

        public LogRepository(QPlanningApplicationContext qPlanningContext, IMapper mapper)
        {
            _qPlanningContext = qPlanningContext;
            _mapper = mapper;
        }
        
        public async Task<BaseResponse> AddExceptionLog(DomainModelExceptionLog domainModelExceptionLog)
        {
           var dbExceptionLog =  _mapper.Map<Entities.Logging.ExceptionLog>(domainModelExceptionLog);
           await _qPlanningContext.ExceptionLog.AddAsync(dbExceptionLog);
           var response = await _qPlanningContext.SaveChangesAsync();
           return new BaseResponse(response.ToString(), true, "Toevoegen exceptionlog gelukt");
        }
        
        public async Task<BaseResponse> AddCustomLog(DomainModelCustomLog domainModelCustomLog)
        {
            var dbCustomLog =  _mapper.Map<Entities.Logging.CustomLog>(domainModelCustomLog);
            await _qPlanningContext.CustomLog.AddAsync(dbCustomLog);
            var response = await _qPlanningContext.SaveChangesAsync();
            return new BaseResponse(response.ToString(), true, "Toevoegen customlog gelukt");
        }
    }
}