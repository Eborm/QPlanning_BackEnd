using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using QPlanning.Business.Domain.Entities.Logging;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.Extensions.Pipeline
{
    public class RequestLoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILoggerService _loggerService;

        public RequestLoggingBehaviour(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var requestObjectName = request.GetType().Name;
            var requestJsonObject = JsonConvert.SerializeObject(request);
            var nextObjectCall = next.Target.GetType().GenericTypeArguments.LastOrDefault()?.Name;
            var customLog = new DomainModelCustomLog
            {
                Level = "Information",
                Message = $"For the object {requestObjectName} the following request is done: {requestJsonObject}",
                RequestObjectName = requestObjectName,
                RequestJsonObject = requestJsonObject,
                DestinationObjectName = nextObjectCall
            };
            
            _loggerService.PersistLogging(customLog);

            return next();
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestObjectName = request.GetType().Name;
            var requestJsonObject = JsonConvert.SerializeObject(request);
            var nextObjectCall = next.Target.GetType().GenericTypeArguments.LastOrDefault()?.Name;
            var customLog = new DomainModelCustomLog
            {
                Level = "Information",
                Message = $"For the object {requestObjectName} the following request is done: {requestJsonObject}",
                RequestObjectName = requestObjectName,
                RequestJsonObject = requestJsonObject,
                DestinationObjectName = nextObjectCall
            };

            _loggerService.PersistLogging(customLog);

            return next();
        }
    }
}