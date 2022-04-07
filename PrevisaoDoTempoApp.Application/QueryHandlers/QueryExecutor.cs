using PrevisaoDoTempoApp.Core.Common.Queries;
using System;

namespace PrevisaoDoTempoApp.Application.QueryHandlers
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly IServiceProvider _context;
        public QueryExecutor(IServiceProvider context)
        {
            _context = context;
        }
        public TResult Execute<T, TResult>(T query) where T : IQuery<TResult>
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var executor = _context.GetService(typeof(IQueryHandler<T, TResult>)) as IQueryHandler<T, TResult>;

            return executor.Execute(query);
        }
    }
}
