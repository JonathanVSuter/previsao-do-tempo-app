namespace PrevisaoDoTempoApp.Core.Common.Queries
{
    public interface IQueryExecutor
    {
        TResult Execute<T, TResult>(T query) where T : IQuery<TResult>;
    }
}
