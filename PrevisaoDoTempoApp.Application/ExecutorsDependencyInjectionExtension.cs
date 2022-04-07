using Microsoft.Extensions.DependencyInjection;
using PrevisaoDoTempoApp.Application.CommandHandlers;
using PrevisaoDoTempoApp.Application.QueryHandlers;
using PrevisaoDoTempoApp.Application.RequestHandlers;
using PrevisaoDoTempoApp.Core.Common.Command;
using PrevisaoDoTempoApp.Core.Common.Queries;
using PrevisaoDoTempoApp.Core.Common.Request;

namespace PrevisaoDoTempoApp.Application
{
    public static class ExecutorsDependencyInjectionExtension
    {
        public static void AddExecutors(this IServiceCollection services)
        {
            services.AddTransient<IRequestExecutor, RequestExecutor>();
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
        }
    }
}
