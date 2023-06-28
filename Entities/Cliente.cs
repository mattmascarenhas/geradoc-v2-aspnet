using geradoc_v2.Entities.Shared;

namespace Geradoc.Domain.Entidades {
    public class Cliente: Entity {
        //private readonly IList<Endereco> _enderecos;

        public Cliente(string primeiroNome, string sobrenome, string cpfCnpj, int rg, string email, string orgaoEmissor, string nacionalidade,
            string estadoCivil, string profissao, string telefone, Endereco endereco){
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;
            CpfCnpj = cpfCnpj;
            Rg = rg;
            Email = email;
            OrgaoEmissor = orgaoEmissor;
            Nacionalidade = nacionalidade;
            EstadoCivil = estadoCivil;
            Profissao = profissao;
            Telefone = telefone;
            Endereco = endereco;
        }

        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }

        public string CpfCnpj { get; private set; }
        public string Email { get; private set; }
        public int Rg { get; private set; }
        public string OrgaoEmissor { get; private set; }
        public string Nacionalidade { get; private set; }
        public string EstadoCivil { get; private set; }
        public string Profissao { get; private set; }
        public string Telefone { get; private set; }
        public Endereco Endereco { get; private set; }



    }
}
