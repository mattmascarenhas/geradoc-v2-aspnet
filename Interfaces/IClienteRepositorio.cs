using Geradoc.Domain.Entidades;

namespace geradoc_v2.Interfaces {
    public interface IClienteRepositorio {
        bool CheckCpfCnpj(string cpfCnpj);
        bool CheckEmail(string email);
        //void Salvar(Cliente cliente);
        //ClienteQuantidadeBlocos ObterQuantidadeBlocosCliente(string cpf);
        //IEnumerable<ClienteExibirLista> Get();
        //IEnumerable<ClientesSemEndereco> GetAll();
        //ClienteExibirLista Get(Guid id);
        //IEnumerable<BlocosClientes> GetBlocos();
    }
}
