namespace PrevisaoDoTempoApp.Core.Common.Queries
{
    public interface IQueryHandler<in T, out TResult> where T : IQuery<TResult>
    {
        TResult Execute(T query);
    }
}
