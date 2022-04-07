using System;
using System.Data.SqlClient;

namespace PrevisaoDoTempoApp.Core.Common.InfraOperations
{
    public interface IDbSession : IDisposable
    {
        Guid Id { get; }
        SqlConnection Connection { get; }
        SqlTransaction Transaction { get; set; }
    }
}
