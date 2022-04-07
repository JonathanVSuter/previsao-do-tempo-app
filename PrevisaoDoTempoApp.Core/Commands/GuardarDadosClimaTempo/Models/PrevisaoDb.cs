namespace PrevisaoDoTempoApp.Core.Commands.GuardarDadosClimaTempo.Models
{
    public class PrevisaoDb
    {
        public int Id { get; set; }
        public string DataConsulta { get; set; }
        public string DataDoClima { get; set; }
        public string Tempo { get; set; }
        public string TemperaturaMinima { get; set; }
        public string TemperaturaMaxima { get; set; }
        public string Iuv { get; set; }
    }
}
