using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroDeSemiJoias.Data;
using RegistroSemijoias.Models;
using RegistroSemijoias.ViewModels;

namespace RegistroSemijoias.Controllers
{
    [ApiController]
    public class RegistroController : ControllerBase
    {
        [HttpPost("v1/Registro")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorRegistroViewModel model,
            [FromServices] RegistroDbContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Semijoias>("error SX01 - Não foi possível estabelecer uma conexão com o servidor"));
            }
            try
            {
                var semijoia = new Semijoias
                {
                    Id = 0,
                    Nome = model.Nome,
                    Descricao = model.Descricao,
                    Preco = model.Preco,
                    ImagemUrl = model.ImagemUrl,
                    Estoque = model.Estoque,
                    Categoria = model.Categoria
                };
                await context.SemiJoias.AddAsync(semijoia);
                await context.SaveChangesAsync();

                return Created($"v1/categories/{semijoia.Id}", new ResultViewModel<Semijoias>(semijoia));
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, new ResultViewModel<Semijoias>("error BX01 - Não foi possível incluir a categoria"));
                //caso não consiga encontrar a categoria, retorna um erro
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Semijoias>("error SX02 - Falha interna no servidor"));

            }


        }
        [HttpGet("v1/Registro/{id:int}")]
        public async Task<IActionResult> GetAsync(
            int id,
            [FromServices] RegistroDbContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Semijoias>("error SX01 - Não foi possível estabelecer uma conexão com o servidor"));
            }
            try
            {
                var semijoia = await context.SemiJoias.FirstOrDefaultAsync(x => x.Id == id);
                if (semijoia == null)
                {
                    return NotFound(new ResultViewModel<Semijoias>("error SX03 - Categoria não encontrada"));
                }
                return Ok(new ResultViewModel<Semijoias>(semijoia));
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, new ResultViewModel<Semijoias>("error BX01 - Não foi possível incluir a categoria"));
                //caso não consiga encontrar a categoria, retorna um erro
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Semijoias>("error SX02 - Falha interna no servidor"));
            }
        }
    }
}
