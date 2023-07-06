using geradoc_v2.Entities.Shared;

namespace Geradoc.Domain.Entidades {
    public class Texto: Entity {
        public Texto(string titulo, string texto) {
            this.Titulo = titulo;
            this.Conteudo = texto;
            DataDeCriacao = DateTime.Now;
            DataDeAtualizacao = DateTime.Now;
        }
        public Texto() {
        }
        public string Titulo { get; private set; }
        public string Conteudo { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public DateTime DataDeAtualizacao { get; private set; }

    }
}
