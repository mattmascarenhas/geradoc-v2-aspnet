using geradoc_v2.Entities.Shared;

namespace geradoc_v2.Entities{
    public class Endereco: Entity {
        public Endereco(string rua, string numero, string complemento, string bairro, string cidade, string estado, string cep){
            this.Rua = rua;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;
            this.Cep = cep;
        }
        public string Rua { get; private set; } 
        public string Numero { get; private set; } 
        public string Complemento { get; private set; } 
        public string Bairro { get; private set; } 
        public string Cidade { get; private set; } 
        public string Estado { get; private set; } 
        public string Cep { get; private set; }

        public override string ToString() {
            return $"{Rua}, {Numero}, {Bairro} - {Cidade}/{Estado}";
        }
    }
}
