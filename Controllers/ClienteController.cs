using Dapper;
using geradoc_v2.Queries;
using Microsoft.AspNetCore.Mvc;
using geradoc_v2.Validations;
using geradoc_v2.Entities;

namespace geradoc_v2.Controllers {
    public class ClienteController : Controller {
        private readonly Database _context;
        public ClienteController(Database context) {
            _context = context;
        }

        //listar todos
        [HttpGet("v1/clients")]
        public IEnumerable<ClienteExibirLista> GetAll() {
            return _context
                   .Connection
                   .Query<ClienteExibirLista>("SELECT c.[Id], CONCAT(c.[PrimeiroNome], ' ', c.[Sobrenome]) AS [Nome], c.[Email], c.[CpfCnpj], c.[Telefone], c.[Rg], c.[OrgaoEmissor], c.[Nacionalidade], c.[EstadoCivil], c.[Profissao], CONCAT(e.[Cidade], ' - ', e.[Estado]) AS [Cidade_Estado], CONCAT(e.[Rua], ', ', e.[Numero], ', ', e.[Complemento], ', ', e.[Bairro], ', ', e.[Cep] ) AS [Endereco] FROM [Clientes] c INNER JOIN [Enderecos] e ON c.[Id] = e.[ClienteId];");
        }

        //listar clientes com quantidade de blocos
        [HttpGet("v1/clients/blocks/qtd")]
        public ClienteQuantidadeBlocos GetOneWithBlocksQuantity(string cpf) {
            return _context
                   .Connection
                   .Query<ClienteQuantidadeBlocos>("spClienteBlocosQuantidade", new {
                       Cpf = cpf
                   }).FirstOrDefault();
        }

        //listar um
        [HttpGet("v1/client/{id}")]
        public ClienteExibirLista GetOne(Guid id) {
            return _context
                   .Connection
                   .Query<ClienteExibirLista>("SELECT c.[Id], CONCAT(c.[PrimeiroNome], ' ', c.[Sobrenome]) AS [Nome], c.[Email], c.[CpfCnpj], c.[Telefone], c.[Rg], c.[OrgaoEmissor], c.[Nacionalidade], c.[EstadoCivil], c.[Profissao], CONCAT(e.[Cidade], '-', e.[Estado]) AS [Cidade_Estado], CONCAT(e.[Rua], '-', e.[Numero], ', ', e.[Complemento], ', ', e.[Bairro], ', ', e.[Cep] ) AS [Endereco] FROM [Clientes] c INNER JOIN [Enderecos] e ON c.[Id] = e.[ClienteId] WHERE c.[Id] = @id;", new {
                       id = id
                   }).FirstOrDefault();
        }

        //criar um
        [HttpPost("v1/client")]
        public object NewClient([FromBody] Cliente _cliente) {
            //verifica se o email ja existe
            if (EmailValidator.CheckEmail(_context, _cliente.Email))
                return BadRequest("O Email já está cadastrado");
            //verificar  o cpf
            if (CpfCnpjValidator.Validate(_cliente.CpfCnpj.ToString()))
                return BadRequest("CPF Inválido");
            //Instancia o cliente
            Cliente cliente = new Cliente(
                            _cliente.PrimeiroNome,
                            _cliente.Sobrenome,
                            _cliente.CpfCnpj,
                            _cliente.Rg,
                            _cliente.Nacionalidade,
                            _cliente.EstadoCivil,
                            _cliente.OrgaoEmissor,
                            _cliente.Profissao,
                            _cliente.Email,
                            _cliente.Telefone,
                            new Endereco(
                                _cliente.Endereco.Numero,
                                _cliente.Endereco.Rua,
                                _cliente.Endereco.Complemento,
                                _cliente.Endereco.Bairro,
                                _cliente.Endereco.Cidade,
                                _cliente.Endereco.Estado,
                                _cliente.Endereco.Cep
                            )
                        );
            try {
                _context.Connection.Execute("spNovoCliente", new {
                    Id = cliente.Id,
                    PrimeiroNome = cliente.PrimeiroNome,
                    Sobrenome = cliente.Sobrenome,
                    CpfCnpj = cliente.CpfCnpj,
                    Rg = cliente.Rg,
                    Nacionalidade = cliente.Nacionalidade,
                    EstadoCivil = cliente.EstadoCivil,
                    OrgaoEmissor = cliente.OrgaoEmissor,
                    Profissao = cliente.Profissao,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone
                }, commandType: System.Data.CommandType.StoredProcedure);

                _context.Connection.Execute("spNovoEndereco", new {
                    Id = cliente.Endereco.Id,
                    ClienteId = cliente.Id,
                    Numero = cliente.Endereco.Numero,
                    Rua = cliente.Endereco.Rua,
                    Complemento = cliente.Endereco.Complemento,
                    Bairro = cliente.Endereco.Bairro,
                    Cidade = cliente.Endereco.Cidade,
                    Estado = cliente.Endereco.Estado,
                    Cep = cliente.Endereco.Cep
                }, commandType: System.Data.CommandType.StoredProcedure);

                return cliente;
            } catch (IOException ex) {
                return BadRequest($"Error: {ex.Message}");
            }
        }
        //editar
        [HttpPut("v1/client/{id}")]
        public object EditClient(Guid id, [FromBody] Cliente _cliente) {
            try {
                //Instancia o cliente
                Cliente cliente = new Cliente(
                                _cliente.PrimeiroNome,
                                _cliente.Sobrenome,
                                _cliente.CpfCnpj,
                                _cliente.Rg,
                                _cliente.Nacionalidade,
                                _cliente.EstadoCivil,
                                _cliente.OrgaoEmissor,
                                _cliente.Profissao,
                                _cliente.Email,
                                _cliente.Telefone,
                                new Endereco(
                                    _cliente.Endereco.Numero,
                                    _cliente.Endereco.Rua,
                                    _cliente.Endereco.Complemento,
                                    _cliente.Endereco.Bairro,
                                    _cliente.Endereco.Cidade,
                                    _cliente.Endereco.Estado,
                                    _cliente.Endereco.Cep )
                                );

                _context.Connection.Execute("spEditarCliente", new {
                    Id = id,
                    PrimeiroNome = cliente.PrimeiroNome,
                    Sobrenome = cliente.Sobrenome,
                    CpfCnpj = cliente.CpfCnpj,
                    Rg = cliente.Rg,
                    Nacionalidade = cliente.Nacionalidade,
                    EstadoCivil = cliente.EstadoCivil,
                    OrgaoEmissor = cliente.OrgaoEmissor,
                    Profissao = cliente.Profissao,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone
                }, commandType: System.Data.CommandType.StoredProcedure);

                _context.Connection.Execute("spEditarEndereco", new {
                    Id = cliente.Endereco.Id,
                    Numero = cliente.Endereco.Numero,
                    Rua = cliente.Endereco.Rua,
                    Complemento = cliente.Endereco.Complemento,
                    Bairro = cliente.Endereco.Bairro,
                    Cidade = cliente.Endereco.Cidade,
                    Estado = cliente.Endereco.Estado,
                    Cep = cliente.Endereco.Cep
                }, commandType: System.Data.CommandType.StoredProcedure);


                return cliente;
            } catch(IOException ex) {
                return BadRequest($"Error: {ex.Message}");

            }
        }
    }
}
