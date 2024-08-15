using FinancialApi.Data;
using FinancialApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinancialApi.Controllers
{
    [Route("address")]
    public class AddressController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Address>>> Get(
            [FromServices] DataContext context
        )
        {
            var address = await context
                .Address
                .AsNoTracking()
                .ToListAsync();
            return Ok(address);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Address>> GetById(
            int id,
            [FromServices] DataContext context
        )
        {
            var address = await context
                .Address
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(address);
        }

        [HttpPost]
        public async Task<ActionResult<Address>> Post(
            [FromBody] Address model,
            [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Address.Add(model);
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
        public async Task<ActionResult<List<Address>>> Put(
            int id,
            [FromBody] Address model,
            [FromServices] DataContext context
        )
        {
            if (id != model.Id)
                return NotFound(new { message = "Nenhum cadastro encontrado." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Address>(model).State = EntityState.Modified;
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
        public async Task<ActionResult<Address>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var address = await context
                .Address
                .FirstOrDefaultAsync(x => x.Id == id);

            if (address == null)
                return NotFound(new { message = "Cadastro não encontrado" });

            try
            {
                context.Address.Remove(address);
                await context.SaveChangesAsync();
                return Ok(new { message = "Cadastro excluído com sucesso." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível excluír o cadastro." });
            }
        }
    }
}