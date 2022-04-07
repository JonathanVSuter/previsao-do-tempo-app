using System.Threading.Tasks;

namespace PrevisaoDoTempoApp.Core.Common.Request
{
    public interface IRequestHandler<T, TResult> where T : IRequest<Task<TResult>>
    {
        Task<TResult> Execute(T query);
    }
}
