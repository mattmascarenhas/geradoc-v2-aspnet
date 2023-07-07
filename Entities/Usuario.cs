using geradoc_v2.Entities.Shared;

namespace geradoc_v2.Entities {
    public class Usuario : Entity {
        public Usuario(string primeiroNome, string sobrenome, string cpfCnpj, string email, string telefone, string senha) {
            this.PrimeiroNome = primeiroNome;
            this.Sobrenome = sobrenome;
            this.CpfCnpj = cpfCnpj;
            this.Telefone = telefone;
            this.Email = email;
            this.Senha = senha;
        }

        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }
        public string CpfCnpj { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Senha { get; private set; }

        public override string ToString() {
            return $"{PrimeiroNome} {Sobrenome}";
        }
    }
}
