using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QPlanning.Business;
using QPlanning.Business.Extensions.Pipeline;

namespace QPlanning.Api.Extensions.ServiceCollection
{
    public static class MediatRServiceCollectionExtension
    {
        public static void AddMediatRComponents(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestTransactionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));
        }
    }
}