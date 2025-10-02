using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using MediatR;
using QPlanning.Business.Interfaces.Base;

namespace QPlanning.Business.Extensions.Pipeline
{
    public class RequestTransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        //TODO: !!! UseCaseResponseMessage SHOULD BE AN ENTERPRISE / APPLICATION WIDE GENERIC RESPONSE !!!
        where TResponse : UseCaseResponseMessage
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };

            using (var transaction = new TransactionScope(TransactionScopeOption.RequiresNew, transactionOptions,
                TransactionScopeAsyncFlowOption.Enabled))
            {
                // handle request handler
                var response = await next();

                // complete database transaction
                if (response.Success)
                    transaction.Complete();

                return response;
            }
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };
            
            // handle request handler
            var response = next();

            return response;
        }
    }
}