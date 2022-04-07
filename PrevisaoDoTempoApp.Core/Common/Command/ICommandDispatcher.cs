namespace PrevisaoDoTempoApp.Core.Common.Command
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command) where T : ICommand;
        TResult Dispatch<T, TResult>(T command) where T : ICommand;
    }
}
