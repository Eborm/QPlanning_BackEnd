using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.Extensions.Pipeline
{
    public class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        // !!! SHOULD BE A GENERIC BASE VERSION RESPONSE TYPE !!!
        where TResponse : BaseResponse
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                var response = new BaseResponse(new List<string>
                {
                    failures.Select(error => error.ErrorMessage).Aggregate((store, seed) => store += $" {seed}")
                });
                return Task.FromResult(response as TResponse);
            }
            else
            {
                return next();
            }
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                var response = new BaseResponse(new List<string>
                {
                    failures.Select(error => error.ErrorMessage).Aggregate((store, seed) => store += $" {seed}")
                });
                return Task.FromResult(response as TResponse);
            }
            else
            {
                return next();
            }
        }
    }
}