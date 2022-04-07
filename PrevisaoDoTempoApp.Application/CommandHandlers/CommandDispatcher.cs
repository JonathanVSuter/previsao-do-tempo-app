using PrevisaoDoTempoApp.Core.Common.Command;
using System;

namespace PrevisaoDoTempoApp.Application.CommandHandlers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Dispatch<T>(T command) where T : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command), "Command cannot be null");

            var service = _serviceProvider.GetService(typeof(ICommandHandler<T>)) as ICommandHandler<T>;
            service.Handle(command);
        }
        public TResult Dispatch<T, TResult>(T command) where T : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command), "Command cannot be null");

            var service = _serviceProvider.GetService(typeof(ICommandHandlerWithResult<T, TResult>)) as ICommandHandlerWithResult<T, TResult>;
            return service.Handle(command);
        }
    }
}