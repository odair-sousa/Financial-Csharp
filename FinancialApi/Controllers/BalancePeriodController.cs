using FinancialApi.Data;
using FinancialApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialApi.Controllers
{
    public class BalancePeriodController : ControllerBase
    {
        [HttpGet]
        [Route("/getBalancePeriods")]
        public async Task<ActionResult<List<BalancePeriod>>> Get(
            [FromServices] DataContext context
        )
        {
            var balancePeriods = await context
                .BalancePeriod
                .AsNoTracking()
                .ToListAsync();
            return Ok(balancePeriods);
        }

        [HttpGet]
        [Route("getBalancePeriodById/{id:int}")]
        public async Task<ActionResult<BalancePeriod>> GetById(
            int id,
            [FromServices] DataContext context
        )
        {
            var balancePeriods = await context
                .BalancePeriod
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(balancePeriods);
        }

        [HttpPost]
        [Route("createBalancePeriod")]
        public async Task<ActionResult<BalancePeriod>> Post(
            [FromBody] BalancePeriod model,
            [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.BalancePeriod.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o período." });
            }
        }

        [HttpPut]
        [Route("/editBalancePeriod")]
        public async Task<ActionResult<BalancePeriod>> Put(
            int id,
            [FromBody] BalancePeriod model,
            [FromServices] DataContext context
        )
        {
            if (id != model.Id)
                return NotFound(new { message = "Nenhum período encontrado." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<BalancePeriod>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível editar o período." });
            }
        }

        [HttpDelete]
        [Route("deleteBalancePeriod/{id:int}")]
        public async Task<ActionResult<BalancePeriod>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var balancePeriods = await context
                .BalancePeriod
                .FirstOrDefaultAsync(x => x.Id == id);

            if (balancePeriods == null)
                return NotFound(new { message = "Período não encontrado." });

            try
            {
                context.BalancePeriod.Remove(balancePeriods);
                await context.SaveChangesAsync();
                return Ok(new { message = "Período financeiro excluído com sucesso." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível excluir o período financeiro." });
            }
        }
    }
}