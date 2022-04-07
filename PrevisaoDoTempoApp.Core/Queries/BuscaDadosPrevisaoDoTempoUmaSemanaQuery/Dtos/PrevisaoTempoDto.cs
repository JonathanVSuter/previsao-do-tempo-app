namespace PrevisaoDoTempoApp.Core.Queries.BuscaDadosPrevisaoDoTempoUmaSemanaQuery.Dtos
{
    public class PrevisaoTempoDto
    {
        public string DataConsulta { get; set; }
        public string DataDoClima { get; set; }
        public string Tempo { get; set; }
        public string TemperaturaMinima { get; set; }
        public string TemperaturaMaxima { get; set; }
    }
}
