using PrevisaoDoTempoApp.Core.Common.Request;
using System;
using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.Application.RequestHandlers
{
    public class RequestExecutor : IRequestExecutor
    {
        private readonly IServiceProvider _serviceProvider;
        public RequestExecutor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Task<TResult> ExecuteRequest<T, TResult>(T request) where T : IRequest<Task<TResult>>
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var service = _serviceProvider.GetService(typeof(IRequestHandler<T, TResult>)) as IRequestHandler<T, TResult>;

            return service.Execute(request);
            //var executor = _context.Resolve<IRequestHandler<T, TResult>>();

            //return executor.Execute(request);
        }
    }
}
