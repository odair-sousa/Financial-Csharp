using FinancialApi.Data;
using FinancialApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinancialApi.Controllers
{
    [Route("people")]
    public class PeopleController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<People>>> Get(
            [FromServices] DataContext context
        )
        {
            var people = await context
                .People
                .AsNoTracking()
                .ToListAsync();
            return Ok(people);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<People>> GetById(
            int id,
            [FromServices] DataContext context
        )
        {
            var people = await context
                .People
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return Ok(people);
        }

        [HttpPost]
        public async Task<ActionResult<People>> Post(
            [FromBody] People model,
            [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.People.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível concluir o cadastro." });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<List<People>>> Put(
            int id,
            [FromBody] People model,
            [FromServices] DataContext context
        )
        {
            if (id != model.Id)
                return NotFound(new { message = "Nenhum cadastro encontrado." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<People>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado por outro usuário." });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<People>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var people = await context
                .People
                .FirstOrDefaultAsync(x => x.Id == id);

            if (people == null)
                return NotFound(new { message = "Cadastro de pessoa não encontrado." });

            try
            {
                context.People.Remove(people);
                await context.SaveChangesAsync();
                return Ok(new { message = "Cadastro excluído com sucesso." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível excluir a pessoa." });
            }
        }
    }
}