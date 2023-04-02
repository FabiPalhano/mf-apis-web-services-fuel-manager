using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vacina_tracker_v2.Models;

namespace vacina_tracker_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinasController : ControllerBase
    {

        private readonly AppDbContext _context;

        public VacinasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Vacinas.ToListAsync();

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Vacinas model)
        {
            _context.Vacinas.Add(model);
            await _context.SaveChangesAsync();

            //return Ok(model);

            return CreatedAtAction("GetById", new { id = model.IdVacina }, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Vacinas
                .Include(t => t.Responsavel)
                .FirstOrDefaultAsync(c => c.IdVacina == id);

            if (model == null) return NotFound();

            GerarLinks(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Vacinas model)
        {
            if (id != model.IdVacina) return BadRequest();
            var modeloDb = await _context.Vacinas.AsNoTracking()
                .FirstOrDefaultAsync(c => c.IdVacina == id);

            if (modeloDb == null) return NotFound();

            _context.Vacinas.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Vacinas.FindAsync(id);

            if (model == null) return NotFound();

            _context.Vacinas.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private void GerarLinks(Vacinas model)
        {
            model.Links.Add(new LinkDto(model.IdVacina, Url.ActionLink(), rel: "self", metodo: "GET"));
            model.Links.Add(new LinkDto(model.IdVacina, Url.ActionLink(), rel: "update", metodo: "PUT"));
            model.Links.Add(new LinkDto(model.IdVacina, Url.ActionLink(), rel: "delete", metodo: "DELETE"));
        }
    }
}
