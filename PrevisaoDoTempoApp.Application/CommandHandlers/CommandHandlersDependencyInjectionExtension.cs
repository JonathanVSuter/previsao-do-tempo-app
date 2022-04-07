using Microsoft.Extensions.DependencyInjection;
using PrevisaoDoTempoApp.Application.CommandHandlers.GuardarDadosCidades;
using PrevisaoDoTempoApp.Application.CommandHandlers.GuardarDadosClimaTempo;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades.Dto;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo;
using PrevisaoDoTempoApp.Core.Common.Command;
using System.Collections.Generic;


namespace PrevisaoDoTempoApp.Application.CommandHandlers
{
    public static class CommandHandlersDependencyInjectionExtension
    {
        public static void AddCommandHandlers(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandlerWithResult<GuardarDadosCidadesCommand, IList<CidadeCommandDto>>, GuardarDadosCidadesCommandHandler>();
            services.AddTransient<ICommandHandler<GuardarDadosClimaTempoCommand>, GuardarDadosClimaTempoUmaSemanaCommandHandler>();
        }
    }
}
