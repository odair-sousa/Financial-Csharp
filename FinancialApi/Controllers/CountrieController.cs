using FinancialApi.Data;
using FinancialApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialApi.Controllers
{
    [Route("countrie")]
    public class CountrieController : ControllerBase
    {
        [HttpGet]
        [Route("getCountries")]
        public async Task<ActionResult<List<Countrie>>> Get(
            [FromServices] DataContext context
        )
        {
            var countrie = await context
                .Countrie
                .AsNoTracking()
                .ToListAsync();
            return Ok(countrie);
        }

        [HttpGet]
        [Route("getCountrieById/{id:int}")]
        public async Task<ActionResult<Countrie>> GetById(
            int id,
            [FromServices] DataContext context
        )
        {
            var countrie = await context
                .Countrie
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(countrie);
        }

        [HttpPost]
        [Route("createCountrie")]
        public async Task<ActionResult<Countrie>> Post(
            [FromBody] Countrie model,
            [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Countrie.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o registro." });
            }
        }

        [HttpPut]
        [Route("editCountrie/{id:int}")]
        public async Task<ActionResult<List<Countrie>>> Put(
            int id,
            [FromBody] Countrie model,
            [FromServices] DataContext context
        )
        {
            if (id != model.Id)
                return NotFound(new { message = "Nenhum registro encontrado." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Countrie>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível editar o registro." });
            }
        }

        [HttpDelete]
        [Route("deleteCountrie/{id:int}")]
        public async Task<ActionResult<City>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var countrie = await context
                .Countrie
                .FirstOrDefaultAsync(x => x.Id == id);

            if (countrie == null)
                return NotFound(new { message = "Registro não encontrado." });

            try
            {
                context.Countrie.Remove(countrie);
                await context.SaveChangesAsync();
                return Ok(new { message = "Registro excluído com sucesso." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível excluir o registro." });
            }
        }
    }
}