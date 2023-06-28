using geradoc_v2.Entities.Shared;

namespace Geradoc.Domain.Entidades {
    public class Bloco: Entity {
        public Bloco(string titulo) {
            this.Titulo = titulo;
            this.DataDeCriacao = DateTime.Now;
            
        }
        public string Titulo { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public DateTime DataDeAtualizacao { get; private set; }

        public override string ToString() {
            return Titulo;
        }
    }
}
