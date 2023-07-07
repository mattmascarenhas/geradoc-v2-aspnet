using Dapper;
using geradoc_v2.Entities;
using geradoc_v2.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace geradoc_v2.Controllers {
    public class TextoController : Controller {
        private readonly Database _context;

        public TextoController(Database context) {
            _context = context;
        }

        //listar todos
        [HttpGet("v1/texts")]
        public IEnumerable<TextoExibirLista> GetAll() {
            return _context
                   .Connection
                   .Query<TextoExibirLista>("SELECT * FROM [Textos]");
        }

        //listar um
        [HttpGet("v1/text/{id}")]
        public TextoExibirLista GetOne(Guid id) {
            return _context
                   .Connection
                   .Query<TextoExibirLista>("SELECT * FROM [Textos] WHERE [Id] = @id", new {
                       id = id
                   }).FirstOrDefault();
        }

        //criar um
        [HttpPost("v1/text")]
        public object CreateText([FromBody] Textos _texto) {
            //instanciar um novo texto
            Textos texto = new Textos(_texto.Titulo, _texto.Texto);

            try {
                _context.Connection.Execute("spNovoTexto", new {
                    Id = texto.Id,
                    Titulo = texto.Titulo,
                    Texto = texto.Texto,
                    DataCriacao = texto.DataDeCriacao
                }, commandType: System.Data.CommandType.StoredProcedure);

                return texto;
            } catch (IOException ex) {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        //editar um
        [HttpPut("v1/text/{id}")]
        public object EditText(Guid id, [FromBody] Textos _texto) {
            //instanciar um novo texto
            Textos texto = new Textos(_texto.Titulo, _texto.Texto);

            try {
                _context.Connection.Execute("spEditarTexto", new {
                    Id = id,
                    Titulo = texto.Titulo,
                    Texto = texto.Texto,
                }, commandType: System.Data.CommandType.StoredProcedure);

                return texto;
            } catch (IOException ex) {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        //deletar um
        [HttpDelete("v1/text/{id}")]
        public object DeleteText(Guid id) {
            try {
                // exclui o usuario do banco de dados usando a stored procedure
                _context.Connection.Execute("spDeletarTexto", new {
                    Id = id
                }, commandType: System.Data.CommandType.StoredProcedure);

                return "Text deleted successfully!";
            } catch {
                return BadRequest("There is an Block using this Text");

            }
        }
    }
}
