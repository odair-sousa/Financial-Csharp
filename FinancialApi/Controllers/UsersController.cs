using FinancialApi.Data;
using FinancialApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialApi.Controllers
{
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("getAllUsers")]
        public async Task<ActionResult<List<Users>>> Get(
            [FromServices] DataContext context
        )
        {
            var users = await context
                .Users
                .AsNoTracking()
                .ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("getUsersById/{id:int}")]
        public async Task<ActionResult<Users>> Get(
            int id,
            [FromServices] DataContext context
        )
        {
            var users = await context
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(users);
        }

        [HttpPost]
        [Route("createUser")]
        public async Task<ActionResult<Users>> Post(
            [FromBody] Users model,
            [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Users.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível concluir o cadastro." });
            }
        }

        [HttpPut]
        [Route("editUser/{id:int}")]
        public async Task<ActionResult<List<Users>>> Put(
            int id,
            [FromBody] Users model,
            [FromServices] DataContext context
        )
        {
            if (id != model.Id)
                return NotFound(new { message = "Nenhum registro encontrado." });

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            try
            {
                context.Entry<Users>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível editar o registro." });
            }
        }

        [HttpDelete]
        [Route("deleteUser/{id:int}")]
        public async Task<ActionResult<Users>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var users = await context
                .Users
                .FirstOrDefaultAsync(x => x.Id == id);

            if (users == null)
                return NotFound(new { message = "Cadastro não encontrado." });

            try
            {
                context.Users.Remove(users);
                await context.SaveChangesAsync();
                return Ok(new { message = "Cadastro excluído com sucesso." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível excluir o resgistro." });
            }
        }
    }
}