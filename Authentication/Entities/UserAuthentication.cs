using geradoc_v2.Entities.Shared;

namespace geradoc_v2.Authentication.Entities {
    public class UserAuthentication: Entity {
        public UserAuthentication() {

        }
        public string Nome { get; private set; }
        public string CpfCnpj { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Senha { get; private set; }

        public override string ToString() {
            return $"{Nome}";
        }
    }
}
