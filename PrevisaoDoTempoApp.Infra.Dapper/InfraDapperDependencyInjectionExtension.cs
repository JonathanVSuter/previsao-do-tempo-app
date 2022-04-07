using Microsoft.Extensions.DependencyInjection;
using PrevisaoDoTempoApp.Core.Common.InfraOperations;
using PrevisaoDoTempoApp.Core.Repositories;
using PrevisaoDoTempoApp.Infra.Dapper.Repositories;
using PrevisaoDoTempoApp.Infra.Dapper.TransactionManagement;

namespace PrevisaoDoTempoApp.Infra.Dapper
{
    public static class InfraDapperDependencyInjectionExtension
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddTransient<IDadosCidadeRepository, DadosCidadeRepository>();
            service.AddTransient<IDadosClimaTempoRepository, DadosClimaTempoRepository>();
        }
        public static void AddInfraOperations(this IServiceCollection service)
        {
            service.AddTransient<IUnitOfWork, UnitOfWork>();
            service.AddTransient<IDbSession, DbSession>();
        }
    }
}
