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
            var model = await _context.Vacina.ToListAsync();

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Vacina model)
        {
            _context.Vacina.Add(model);
            await _context.SaveChangesAsync();

            //return Ok(model);

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Vacina
                .Include(t => t.Responsavel).ThenInclude(t => t.Responsavel)
                .Include(t => t.Responsavel)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            GerarLinks(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Vacina model)
        {
            if (id != model.Id) return BadRequest();
            var modeloDb = await _context.Vacina.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            _context.Vacina.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Vacina.FindAsync(id);

            if (model == null) return NotFound();

            _context.Vacina.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private void GerarLinks(Vacina model)
        {
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "self", metodo: "GET"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "update", metodo: "PUT"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "delete", metodo: "DELETE"));
        }

        [HttpPost("{id}/responsaveis")]
        public async Task<ActionResult> AddResponsavel(int id, VacinasUsuarios model)
        {
            if (id != model.VacinaId) return BadRequest();
            _context.VacinasUsuarios.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.VacinaId }, model);
        }

        [HttpDelete("{id}/responsaveis/{ResponsavelId}")]
        public async Task<ActionResult> DeleteResponsavel(int id, int ResponsavelId)
        {
            var model = await _context.VacinasUsuarios
                .Where(c => c.VacinaId == id && c.ResponsavelId == ResponsavelId)
                .FirstOrDefaultAsync();

            if (model == null) return NotFound();

            _context.VacinasUsuarios.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
