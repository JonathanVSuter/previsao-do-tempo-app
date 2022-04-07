using Microsoft.Extensions.Options;
using PrevisaoDoTempoApp.Core.Common.InfraOperations;
using PrevisaoDoTempoApp.Core.Configuration;
using System;
using System.Data.SqlClient;

namespace PrevisaoDoTempoApp.Infra.Dapper.TransactionManagement
{
    public class DbSession : IDbSession
    {
        public SqlConnection Connection { get; }
        public SqlTransaction Transaction { get; set; }
        public Guid Id { get; }
        public DbSession(IOptions<ApiConfiguration> options)
        {
            Id = Guid.NewGuid();
            Connection = new SqlConnection(options.Value.SqlServerConnection);
            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();
    }
}
