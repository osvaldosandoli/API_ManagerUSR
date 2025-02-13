using Microsoft.AspNetCore.Mvc;
using API_Manager.Model;
using System.Collections.Generic;
using API_Manager.Database;
using Swashbuckle.AspNetCore.Annotations;

namespace API_Manager.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly Config _context;

        public UserController(Config context)
        {
            _context = context;
        }

        /* POST  para adicionar um usuario */
        [HttpPost("PostUser")]
        public IActionResult PostUser([FromBody] Users user)
        {
            if (string.IsNullOrEmpty(user.name) || string.IsNullOrEmpty(user.email) || string.IsNullOrEmpty(user.pass))
            {
                return BadRequest("Todos os campos são obrigatórios.");
            }

            _context.Users.Add(user);
            _context.SaveChanges();



            return Ok("ID do usuario adicionado : " + user.id);

        }

        /* GET para retornar todos os usuarios cadastrados */
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        /*GET para retornar apenas o ID do usuario */
        [HttpGet("GetOneUser/{id}")]
        public IActionResult GetOneUser(int id)
        {
            var users = _context.Users.Find(id);
            if (users == null)
            {
                return NotFound(new { message = "Usuário não encontrado!" });
            }
            return Ok(users);
        }

        /* PUT para editar apenas o usuario que foi passado o ID */
        [HttpPut("PutOneUser/{id}")]
        public IActionResult PutOneUser(int id, [FromBody] Users updatedUser)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound(new { message = "Usuário não encontrado!" });
            }

            user.name = updatedUser.name;
            user.email = updatedUser.email;
            user.pass = updatedUser.pass;

            _context.Users.Update(user);
            _context.SaveChanges();

            return Ok(new { message = "Usuário atualizado com sucesso!", user });
        }

        /* DELETE para deletar o usuario que recebe o ID */
        [HttpDelete("DeleteOneUser/{id}")]
        public IActionResult DeleteOneUser(int id)
        {
            var users = _context.Users.Find(id);

            if (users == null)
            {
                return NotFound(new { message = "Usuário não encontrado!" });
            }

            _context.Users.Remove(users);
            _context.SaveChanges();
            return Ok(new { message = "Usuário removido com sucesso!" });
        }

        /* DELETE para remover todos os Usuarios */
        [HttpDelete("DeleteAllUsers")]
        public IActionResult DeleteAllUsers()
        {

            var users = _context.Users.ToList();

            _context.Users.RemoveRange(users);
            _context.SaveChanges();

            return Ok(new { message = "Todos os usuarios foram removidos!" });
        }


    }
}
