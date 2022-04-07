namespace PrevisaoDoTempoApp.Core.Common.Command
{
    public interface ICommandHandlerWithResult<in T, out TResult>
    {
        TResult Handle(T command);
    }
}
