using FinancialApi.Data;
using FinancialApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialApi.Controllers
{
    public class CityController : ControllerBase
    {
        [HttpGet]
        [Route("getAllCities")]
        public async Task<ActionResult<List<City>>> Get(
            [FromServices] DataContext context
        )
        {
            var city = await context
                .City
                .AsNoTracking()
                .ToListAsync();
            return Ok(city);
        }

        [HttpGet]
        [Route("getCityById/{id:int}")]
        public async Task<ActionResult<City>> GetById(
            int id,
            [FromServices] DataContext context
        )
        {
            var city = await context
                .City
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(city);
        }

        [HttpPost]
        [Route("createCity")]
        public async Task<ActionResult<City>> Post(
            [FromBody] City model,
            [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.City.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível concluir o cadastro." });
            }
        }

        [HttpPut]
        [Route("editCity/{id:int}")]
        public async Task<ActionResult<City>> Put(
            int id,
            [FromBody] City model,
            [FromServices] DataContext context
        )
        {
            if (id != model.Id)
                return NotFound(new { message = "Nenhuma cidade foi encontrada." });

            if (!ModelState.IsValid)
                BadRequest(ModelState);

            try
            {
                context.Entry<City>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível editar a cidade." });
            }
        }

        [HttpDelete]
        [Route("deleteCity/{id:int}")]
        public async Task<ActionResult<City>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            var city = await context
                .City
                .FirstOrDefaultAsync(x => x.Id == id);

            if (city == null)
                return NotFound(new { message = "Cidade não encontrada." });

            try
            {
                context.City.Remove(city);
                await context.SaveChangesAsync();
                return Ok(new { message = "Cidade excluída com sucesso." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível excluir a cidade." });
            }
        }
    }
}