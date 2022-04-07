using Dapper;
using Microsoft.Extensions.Options;
using PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo.Models;
using PrevisaoDoTempoApp.Core.Common.InfraOperations;
using PrevisaoDoTempoApp.Core.Configuration;
using PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery.Dtos;
using PrevisaoDoTempoApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrevisaoDoTempoApp.Infra.Dapper.Repositories
{
    public class DadosClimaTempoRepository : IDadosClimaTempoRepository
    {
        private readonly IOptions<ApiConfiguration> _options;
        private readonly IUnitOfWork _unitOfWork;

        public DadosClimaTempoRepository(IOptions<ApiConfiguration> options, IUnitOfWork unitOfWork)
        {
            _options = options;
            _unitOfWork = unitOfWork;
        }
        public IList<PrevisaoTempoDto> BuscarPrevisaoDoTempoUmaSemana(string codigoCidade)
        {
            var sql = @"SELECT TOP 7 CASE ct.Tempo 
							WHEN 'ec' THEN 'Encoberto com Chuvas Isoladas'
							WHEN 'ci' THEN 'Chuvas Isoladas'
							WHEN 'c' THEN 'Chuva'
							WHEN 'in' THEN 'Instável'
							WHEN 'pp' THEN 'Possibilidade de Pancadas de Chuva'
							WHEN 'cm' THEN 'Chuva pela Manhã'
							WHEN 'cn' THEN 'Chuva pela Noite'
							WHEN 'pt' THEN 'Pancadas de Chuva a Tarde'
							WHEN 'pm' THEN 'Pancadas de Chuva pela Manhã'
							WHEN 'np' THEN 'Nublado e Pancadas de Chuva'
							WHEN 'pc' THEN 'Pancadas de Chuva'
							WHEN 'pn' THEN 'Parcialmente Nublado'
							WHEN 'cv' THEN 'Chuvisco'
							WHEN 'ch' THEN 'Chuvoso'
							WHEN 't' THEN 'Tempestade'
							WHEN 'ps' THEN 'Predomínio de Sol'
							WHEN 'e' THEN 'Encoberto'
							WHEN 'n' THEN 'Nublado'
							WHEN 'cl' THEN 'Céu Claro'
							WHEN 'nv' THEN 'Nevoeiro'
							WHEN 'g' THEN 'Geada'
							WHEN 'ne' THEN 'Neve'
							WHEN 'pnt' THEN 'Pancadas de Chuva a Noite'
							WHEN 'psc' THEN 'Possibilidade de Chuva'
							WHEN 'pcm' THEN 'Possibilidade de Chuva pela Manhã'
							WHEN 'pct' THEN 'Possibilidade de Chuva a Tarde'
							WHEN 'pcn' THEN 'Possibilidade de Chuva a Noite'
							WHEN 'npt' THEN 'Nublado com Pancadas a Tarde'
							WHEN 'npn' THEN 'Nublado com Pancadas a Noite'
							WHEN 'ncn' THEN 'Nublado com Possibilidade de Chuva a Noite'
							WHEN 'nct' THEN 'Nublado com Possibilidade de Chuva a Tarde'
							WHEN 'ncm' THEN 'Nublado com Possibilidade de Chuva pela Manhã'
							WHEN 'npm' THEN 'Nublado com Pancadas pela Manhã'
							WHEN 'npp' THEN 'Nublado com Possibilidade de Chuva'
							WHEN 'vn' THEN 'Variação de Nebulosidade'
							WHEN 'ct' THEN 'Chuva a Tarde'
							WHEN 'ppn' THEN 'Possibilidade de Pancadas de Chuva a Noite'
							WHEN 'ppt' THEN 'Possibilidade de Pancadas de Chuva a Tarde'
							WHEN 'ppm' THEN 'Possibilidade de Pancadas de Chuva pela Manhã'
							WHEN 'lt' THEN 'Não Definido'
						ELSE '' END AS Tempo, FORMAT(pt.DataClima,'dd/MM/yyyy') AS DataDoClima, FORMAT(pt.DataConsulta,'dd/MM/yyyy') as DataConsulta, ct.Minima as TemperaturaMinima, ct.Maxima as TemperaturaMaxima  from Previsao_Tempo pt 
						INNER JOIN Cidade c on pt.IdCidade = c.Id
						INNER JOIN Clima_Tempo ct on pt.IdClimaTempo = ct.Id
						WHERE C.Id = @codigoCidade ORDER BY pt.DataClima, pt.DataConsulta DESC";
            var parameters = new
            {
                codigoCidade
            };

            using (var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection))
            {
                var result = sqlConnection.Query<PrevisaoTempoDto>(sql, parameters);
                return result.AsList();
            }
        }

        public void GuardarDadosClima(IList<PrevisaoDb> previsoes)
        {
            var sql = @"BEGIN
							DECLARE
								@id INT,
								@Tempo VARCHAR(5),
								@TempMax float,
								@TempMin float,
								@Iuv float

								SELECT @id = ct.Id, @Tempo = ct.Tempo, @TempMax = ct.Maxima, @TempMin = ct.Minima, @Iuv = ct.Iuv 
								FROM Clima_Tempo ct 
								WHERE ct.Iuv = @iuv_p AND ct.Maxima = @tempMax_p AND ct.Minima = @tempMin_p AND ct.Tempo = @tempo_p
								IF LEN(ISNULL(CAST(@id AS varchar(50)),'')) = 0
									BEGIN 
										INSERT INTO [dbo].[Clima_Tempo]
											   ([Tempo]
											   ,[Maxima]
											   ,[Minima]
											   ,[Iuv])
										 OUTPUT inserted.Id
										 VALUES
											   (@tempo_p
											   ,@tempMax_p
											   ,@tempMin_p
											   ,@iuv_p)
									END
								ELSE
									BEGIN
										SELECT @id
									END
						  END";
            foreach (var item in previsoes)
            {
                using (var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection))
                using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@iuv_p", item.Iuv);
                    cmd.Parameters.AddWithValue("@tempMax_p", item.TemperaturaMaxima);
                    cmd.Parameters.AddWithValue("@tempMin_p", item.TemperaturaMinima);
                    cmd.Parameters.AddWithValue("@tempo_p", item.Tempo);

                    sqlConnection.Open();
                    var result = (int)cmd.ExecuteScalar();
                    sqlConnection.Close();
                    item.Id = result;
                };
            }
        }

        public void VincularCidadeEClimas(CidadePrevisaoDoTempoDb cidadeEPrevisoes)
        {
            var sql = @"INSERT INTO [dbo].[Previsao_Tempo]
							   ([IdCidade]
							   ,[IdClimaTempo]
							   ,[DataConsulta]
							   ,[DataClima])
						 VALUES
							   (@idCidade
							   ,@idClimaTempo
							   ,@dataConsulta
							   ,@dataClima)";

            foreach (var previsao in cidadeEPrevisoes.Previsao)
            {
                try
                {
                    var parametros = new
                    {
                        idCidade = cidadeEPrevisoes.IdCidade,
                        idClimaTempo = previsao.Id,
                        dataConsulta = previsao.DataConsulta,
                        dataClima = previsao.DataDoClima
                    };

                    using (var sqlConnection = new SqlConnection(_options.Value.SqlServerConnection))
                    {
                        sqlConnection.Execute(sql, parametros);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
