using Dapper;
using Geradoc.Domain.Entidades;
using geradoc_v2.Queries;
using Microsoft.AspNetCore.Mvc;

namespace geradoc_v2.Controllers {
    public class BlocoController : Controller {
        private readonly Database _context;

        public BlocoController(Database context) {
            _context = context;
        }

        //listar todos
        [HttpGet("v1/blocks")]
        public IEnumerable<BlocoExibirLista> GetAll() {
            return _context
                   .Connection
                   .Query<BlocoExibirLista>("SELECT * FROM [Blocos]");
        }
        //listar um
        [HttpGet("v1/block/{id}")]
        public BlocoExibirLista GetOne(Guid id) {
            return _context
                   .Connection
                   .Query<BlocoExibirLista>("SELECT * FROM [Blocos] WHERE [Id] = @id", new {
                       id = id
                   }).FirstOrDefault();
        }
        //criar um
        [HttpPost("v1/block")]
        public object CreateBlock([FromBody]Bloco _bloco) {
            Bloco bloco = new Bloco(_bloco.Titulo);
            try {
                _context.Connection.Execute("spNovoBloco", new {
                    Id = bloco.Id,
                    Titulo = bloco.Titulo,
                    DataCriacao = bloco.DataDeCriacao
                }, commandType: System.Data.CommandType.StoredProcedure);
                return bloco;
            } catch(IOException ex) {
                return BadRequest($"Error: {ex.Message}");
            }
        }
        //editar bloco
        [HttpPut("v1/block/{id}")]
        public object EditBlock(Guid id, [FromBody]Bloco _bloco) {
            Bloco bloco = new Bloco(_bloco.Titulo);

            try {
                _context.Connection.Execute("spEditarBloco", new {
                    BlocoId = id,
                    Titulo = bloco.Titulo
                }, commandType: System.Data.CommandType.StoredProcedure);

                return bloco;
            } catch (IOException ex) {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        //deletar um
        [HttpDelete("v1/block/{id}")]
        public object DeleteBlock(Guid id) {
            try {
                // exclui o usuario do banco de dados usando a stored procedure
                _context.Connection.Execute("spDeletarBloco", new {
                    Id = id
                }, commandType: System.Data.CommandType.StoredProcedure);

                return "Block deleted successfully!";
            } catch {
                return BadRequest("There is an Client using this Block");

            }
        }
    }
}
