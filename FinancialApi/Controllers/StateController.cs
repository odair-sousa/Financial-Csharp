using FinancialApi.Data;
using FinancialApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinancialApi.Controllers
{
    public class StateController : ControllerBase
    {
        [HttpGet]
        [Route("getAllStates")]
        public async Task<ActionResult<List<State>>> Get(
            [FromServices] DataContext context
        )
        {
            var state = await context
                .State
                .AsNoTracking()
                .ToListAsync();
            return Ok(state);
        }

        [HttpGet]
        [Route("getStateById/{id:int}")]
        public async Task<ActionResult<State>> Get(
            int id,
            [FromServices] DataContext context
        )
        {
            var state = await context
                .State
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(state);
        }

        [HttpPost]
        [Route("createState")]
        public async Task<ActionResult<MonthlyBills>> Post(
            [FromBody] State model,
            [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.State.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível concluir o cadastro." });
            }
        }

        [HttpPut]
        [Route("editState/{id:int}")]
        public async Task<ActionResult<List<State>>> Put(
            int id,
            [FromBody] State model,
            [FromServices] DataContext context
        )
        {
            if (id != model.Id)
                return NotFound(new { message = "Nenhum registro encontrado." });

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            try
            {
                context.Entry<State>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível editar o registro." });
            }
        }

        [HttpDelete]
        [Route("deleteState/{id:int}")]
        public async Task<ActionResult<State>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var state = await context
                .State
                .FirstOrDefaultAsync(x => x.Id == id);

            if (state == null)
                return NotFound(new { message = "Cadastro não encontrado." });

            try
            {
                context.State.Remove(state);
                await context.SaveChangesAsync();
                return Ok(new { message = "Cadastro excluído com sucesso." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível excluir o cadastro." });
            }
        }
    }
}