using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geradoc_v2.Queries {
    public class ClienteExibirLista {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string OrgaoEmissor { get; set; }
        public string Nacionalidade { get; set; }
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }
        public string Endereco { get; set; }
        public string Cidade_Estado { get; set; } 

    }
}
