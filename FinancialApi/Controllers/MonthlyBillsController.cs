using FinancialApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinancialApi.Controllers
{
    public class MonthlyBillsController : ControllerBase
    {
        [HttpGet]
        [Route("getAllBills")]
        public async Task<ActionResult<List<MonthlyBills>>> Get(
            [FromServices] DataContext context
        )
        {
            var monthlyBills = await context
                .MonthlyBills
                .AsNoTracking()
                .ToListAsync();
            return Ok(monthlyBills);
        }

        [HttpGet]
        [Route("getBillsById/{id:int}")]
        public async Task<ActionResult<MonthlyBills>> GetById(
            int id,
            [FromServices] DataContext context
        )
        {
            var monthlyBills = await context
                .MonthlyBills
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(monthlyBills);
        }

        [HttpPost]
        [Route("createBills")]
        public async Task<ActionResult<MonthlyBills>> Post(
            [FromBody] MonthlyBills model,
            [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.MonthlyBills.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível concluir o cadastro." });
            }
        }

        [HttpPut]
        [Route("editBills/{id:int}")]
        public async Task<ActionResult<List<MonthlyBills>>> Put(
            int id,
            [FromBody] MonthlyBills model,
            [FromServices] DataContext context
        )
        {
            if (id != model.Id)
                return NotFound(new { message = "Nunhum registro encontrado." });

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            try
            {
                context.Entry<MonthlyBills>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível editar o registro." });
            }
        }

        [HttpDelete]
        [Route("deleteBills")]
        public async Task<ActionResult<MonthlyBills>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var monthlyBills = await context
                .MonthlyBills
                .FirstOrDefaultAsync(x => x.Id == id);

            if (monthlyBills == null)
                return NotFound(new { message = "Nenhum registro encontrado." });

            try
            {
                context.MonthlyBills.Remove(monthlyBills);
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