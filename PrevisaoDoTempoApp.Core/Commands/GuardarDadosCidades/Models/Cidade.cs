namespace PrevisaoDoTempoApp.Core.Commands.GuardarDadosCidades.Models
{
    public class Cidade
    {
        public string Nome { get; set; }
        public string Uf { get; set; }
        public string Id { get; set; }

        public Cidade(string nome, string uf, string id)
        {
            //colocar as validações business exceptions

            Nome = nome;
            Uf = uf;
            Id = id;
        }
    }
}
