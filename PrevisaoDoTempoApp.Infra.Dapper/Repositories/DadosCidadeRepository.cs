using Dapper;
using Microsoft.Extensions.Options;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades.Dto;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades.Models;
using PrevisaoDoTempoApp.Core.Configuration;
using PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery.Dtos;
using PrevisaoDoTempoApp.Core.Queries.BuscarDadosCidadeQuery.Dtos;
using PrevisaoDoTempoApp.Core.Queries.ListarTodasAsCidades.Dtos;
using PrevisaoDoTempoApp.Core.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrevisaoDoTempoApp.Infra.Dapper.Repositories
{
    public class DadosCidadeRepository : IDadosCidadeRepository
    {
        private readonly IOptions<ApiConfiguration> _options;
        public DadosCidadeRepository(IOptions<ApiConfiguration> options)
        {
            _options = options;
        }

        public CidadePrevisaoDto BuscarCidadePorId(string idCidade)
        {
            var sql = @"SELECT Id, Nome, Uf FROM Cidade c WHERE c.Id = @idCidade";

            var parameters = new
            {
                idCidade
            };

            using (var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection))
            {
                var result = sqlConnection.QueryFirstOrDefault<CidadePrevisaoDto>(sql, parameters);
                return result;
            }
        }

        public IEnumerable<CidadesQueryDto> BuscarCidadesPorNome(string cidade)
        {
            var sql = @"SELECT Id, Nome, Uf FROM Cidade c WHERE c.Nome LIKE CONCAT('%',@nomeCidade,'%')";

            var parameters = new
            {
                nomeCidade = cidade
            };

            using (var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection))
            {
                var result = sqlConnection.Query<CidadesQueryDto>(sql, parameters);
                return result;
            }
        }

        public IList<CidadeCommandDto> InserirERetornarCidades(IList<Cidade> cidades)
        {
            var listaInseridos = new List<CidadeCommandDto>();
            var sql = @"BEGIN 
	                        DECLARE 
		                        @id INT,
		                        @Nome Varchar(100),
		                        @Uf varchar(5);

		                        SELECT @id = c.Id, @Nome = c.Nome, @Uf = c.Uf FROM Cidade c where c.Id = @idCidade_p		                        
		                        IF LEN(ISNULL(CAST(@id AS varchar(50)),'')) = 0
		                        BEGIN 
			                        INSERT INTO [dbo].[Cidade] ([Id],[Nome],[Uf]) 
                                    OUTPUT inserted.Id as Id, inserted.Nome as Nome, inserted.Uf as Uf
			                        VALUES (@idCidade_p, @nomeCidade_p, @uf_p)
		                        END
		                        ELSE
		                        BEGIN
			                        SELECT @id as Id, @Nome as Nome, @Uf as Uf
		                        END
                        END";
            foreach (var cidade in cidades)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idCidade_p", cidade.Id,System.Data.DbType.Int64);
                parameters.Add("nomeCidade_p", cidade.Nome, System.Data.DbType.String);
                parameters.Add("uf_p", cidade.Uf, System.Data.DbType.String);                
                using (var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection))
                {
                    var result = sqlConnection.QueryFirstOrDefault<CidadeCommandDto>(sql, parameters);
                    listaInseridos.Add(result);
                }
            }
            return listaInseridos;
        }

        public IList<ListarTodasAsCidadesDto> ListarTodasAsCidades()
        {
            var sql = @"SELECT   [Id]
                                ,[Nome]
                                ,[Uf]
                        FROM [Cidade]";

            using (var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection))
            {
                var result = sqlConnection.Query<ListarTodasAsCidadesDto>(sql);
                return result.AsList();
            }
        }
    }
}
