using System.Xml.Serialization;

namespace PrevisaoDoTempoApp.Http.BuscarDadosDaCidade.ValueObject
{
    [XmlRoot(ElementName = "cidade")]
    public class Cidade
    {
        [XmlElement(ElementName = "nome")]
        public string Nome { get; set; }
        [XmlElement(ElementName = "uf")]
        public string Uf { get; set; }
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
    }
}
