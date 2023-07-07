using Dapper;
using geradoc_v2.Authentication;
using geradoc_v2.Authentication.Entities;
using geradoc_v2.Entities;
using geradoc_v2.Queries;
using geradoc_v2.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace geradoc_v2.Controllers {
    public class UsuarioController: Controller {
        private readonly Database _context;

        public UsuarioController(Database context) {
            _context = context;
        }
        //listar todos
        [HttpGet("v1/users")]
        public IEnumerable<UsuarioExibirLista> GetAll() {
            return _context
                   .Connection
                   .Query<UsuarioExibirLista>("SELECT * FROM [Usuarios]");
        }
        //listar um
        [HttpGet("v1/user/{id}")]
        public UsuarioExibirLista GetOne(Guid id) {
            return _context
                   .Connection
                   .Query<UsuarioExibirLista>("SELECT * FROM [Usuarios] WHERE [Id] = @id;", new {
                       id = id
                   }).FirstOrDefault();
        }
        //criar um
        [HttpPost("v1/user")]
        public object CreateUser([FromBody] Usuario _usuario) {
            //verifica se o email ja existe
            if (EmailValidator.CheckEmailUser(_context, _usuario.Email))
                return BadRequest("O Email já está cadastrado");
            //verificar  o cpf
            if (CpfCnpjValidator.Validate(_usuario.CpfCnpj.ToString()))
                return BadRequest("CPF Inválido");
            //iniciar o novo usuario
            Usuario usuario = new Usuario(_usuario.PrimeiroNome, _usuario.Sobrenome, _usuario.CpfCnpj,
                _usuario.Email, _usuario.Telefone, _usuario.Senha);
           
            try {
                _context.Connection.Execute("spNovoUsuario", new {
                    Id = usuario.Id,
                    PrimeiroNome = usuario.PrimeiroNome,
                    Sobrenome = usuario.Sobrenome,
                    CpfCnpj = usuario.CpfCnpj,
                    Email = usuario.Email,
                    Telefone = usuario.Telefone,
                    Senha = usuario.Senha
                }, commandType: System.Data.CommandType.StoredProcedure);
                return usuario;
            } catch (IOException ex) {
                return BadRequest($"Error: {ex.Message}");
            }
        }
        //editar um
        [HttpPut("v1/user/{id}")]
        public object EditUser(Guid id, [FromBody]Usuario _usuario) {
            //iniciar o novo usuario
            Usuario usuario = new Usuario(_usuario.PrimeiroNome, _usuario.Sobrenome, _usuario.CpfCnpj,
                _usuario.Email, _usuario.Telefone, _usuario.Senha);

            try {
                _context.Connection.Execute("spEditarUsuario", new {
                    Id = id,
                    PrimeiroNome = usuario.PrimeiroNome,
                    Sobrenome = usuario.Sobrenome,
                    CpfCnpj = usuario.CpfCnpj,
                    Email = usuario.Email,
                    Telefone = usuario.Telefone,
                    Senha = usuario.Senha
                }, commandType: System.Data.CommandType.StoredProcedure);
                return usuario;
            } catch (IOException ex) {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        //deletar um
        [HttpDelete("v1/user/{id}")]
        public object DeleteUser(Guid id) {
            try {
                // exclui o usuario do banco de dados usando a stored procedure
                _context.Connection.Execute("spDeletarUsuario", new {
                    Id = id
                }, commandType: System.Data.CommandType.StoredProcedure);

                return "User deleted successfully!";
            } catch {
                return BadRequest("User cannot be deleted!");

            }
        }

        //autenticar
        [HttpPost("v1/authentication")]
        public IActionResult Authentication([FromBody] AuthenticationRequest _request) {
            // Verificar se o email e a senha são válidos
            if (!IsValidCredentials(_request.Email, _request.Password))
                return Unauthorized("Credenciais inválidas");

            var user = _context.Connection.QueryFirstOrDefault<UserAuthentication>("SELECT [Id], CONCAT([PrimeiroNome], ' ',[Sobrenome]) AS [Nome], [Email], [CpfCnpj], [Telefone], [Senha] FROM [Usuarios] WHERE [Email] = @Email",
        new {
            Email = _request.Email
        });

            // Lógica para gerar token de autenticação
            var token = GenerateToken(user);
            // Retornar o token para o cliente
            return Ok(new {
                Id = user.Id,
                Nome = user.Nome,
                Email = _request.Email,
                CpfCnpj = user.CpfCnpj,
                Telefone = user.Telefone,
                Token = token
            });
        }

        private bool IsValidCredentials(string email, string senha) {
            var user = _context.Connection.QueryFirstOrDefault<UserAuthentication>("SELECT [Id], CONCAT([PrimeiroNome], ' ',[Sobrenome]) AS [Nome], [Email], [CpfCnpj], [Telefone], [Senha] FROM [Usuarios] WHERE [Email] = @Email",
                new {
                    Email = email
                });

            if (user == null)
                return false;

            // Lógica para comparar senhas
            if (user.Senha != senha)
                return false;

            return true;
        }

        private static string GenerateToken(UserAuthentication _user) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, _user.Id.ToString()),
                    new Claim(ClaimTypes.Name, _user.Nome)
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }

}
