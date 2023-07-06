using Dapper;
using Geradoc.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace geradoc_v2.Controllers {
    public class TextoController : Controller {
        private readonly Database _context;

        public TextoController(Database context) {
            _context = context;
        }

        //listar todos
        [HttpGet("v1/texts")]
        public IEnumerable<Texto> GetAll() {
            return _context
                   .Connection
                   .Query<Texto>("SELECT * FROM [Textos]");
        }
    }
}
