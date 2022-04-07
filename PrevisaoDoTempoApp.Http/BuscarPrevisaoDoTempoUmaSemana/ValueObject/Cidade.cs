using System.Collections.Generic;
using System.Xml.Serialization;

namespace PrevisaoDoTempoApp.Http.BuscarPrevisaoDoTempoUmaSemana.ValueObject
{
    [XmlRoot(ElementName = "cidade")]
    public class Cidade
    {
        [XmlElement(ElementName = "nome")]
        public string Nome { get; set; }
        [XmlElement(ElementName = "uf")]
        public string Uf { get; set; }
        [XmlElement(ElementName = "atualizacao")]
        public string Atualizacao { get; set; }
        [XmlElement(ElementName = "previsao")]
        public List<Previsao> Previsao { get; set; }
    }
}
