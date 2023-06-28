using geradoc_v2.Entities.Shared;

namespace Geradoc.Domain.Entidades {
    public class Textos: Entity {
        public Textos(string titulo, string texto) {
            this.Titulo = titulo;
            this.Texto = texto;
            DataDeCriacao = DateTime.Now;
        }
        public string Titulo { get; private set; }
        public string Texto { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public DateTime DataDeAtualizacao { get; private set; }

    }
}
