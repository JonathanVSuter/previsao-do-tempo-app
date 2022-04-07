using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.Core.Common.Request
{
    public interface IRequestExecutor
    {
        Task<TResult> ExecuteRequest<T, TResult>(T request) where T : IRequest<Task<TResult>>;
    }
}
