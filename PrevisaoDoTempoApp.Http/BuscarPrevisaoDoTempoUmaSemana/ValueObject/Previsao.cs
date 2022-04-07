using System.Xml.Serialization;

namespace PrevisaoDoTempoApp.Http.BuscarPrevisaoDoTempoUmaSemana.ValueObject
{
    [XmlRoot(ElementName = "previsao")]
    public class Previsao
    {
        [XmlElement(ElementName = "dia")]
        public string Dia { get; set; }
        [XmlElement(ElementName = "tempo")]
        public string Tempo { get; set; }
        [XmlElement(ElementName = "maxima")]
        public string Maxima { get; set; }
        [XmlElement(ElementName = "minima")]
        public string Minima { get; set; }
        [XmlElement(ElementName = "iuv")]
        public string Iuv { get; set; }
    }
}
