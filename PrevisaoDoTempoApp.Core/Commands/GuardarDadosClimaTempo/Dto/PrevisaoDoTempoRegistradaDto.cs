namespace PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo.Dto
{
    public class PrevisaoDoTempoRegistradaDto
    {
        public string Id { get; set; }
        public string DataConsulta { get; set; }
        public string DataDoClima { get; set; }
        public string Tempo { get; set; }
        public string TemperaturaMinima { get; set; }
        public string TemperaturaMaxima { get; set; }
        public string Iuv { get; set; }
    }
}
