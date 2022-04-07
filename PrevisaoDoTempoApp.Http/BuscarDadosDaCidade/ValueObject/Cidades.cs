using System.Collections.Generic;
using System.Xml.Serialization;

namespace PrevisaoDoTempoApp.Http.BuscarDadosDaCidade.ValueObject
{
    [XmlRoot(ElementName = "cidades")]
    public class Cidades
    {
        [XmlElement(ElementName = "cidade")]
        public List<Cidade> Cidade { get; set; }
    }
}
