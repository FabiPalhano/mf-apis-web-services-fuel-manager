using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vacina_tracker_v2.Models;

namespace vacina_tracker_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsaveisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResponsaveisController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Responsavel.ToListAsync();

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ResponsavelDto model)
        {
            Responsavel novo = new Responsavel()
            {
                Nome = model.Nome,
                Email = model.Email,
                Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha),
                TipoUsuario = model.TipoUsuario,
        };
            
            _context.Responsavel.Add(novo);
            await _context.SaveChangesAsync();

            //return Ok(model);

            return CreatedAtAction("GetById", new { id = novo.Id }, novo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Responsavel
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            GerarLinks(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ResponsavelDto model)
        {
            if (id != model.Id) return BadRequest();
            var modeloDb = await _context.Responsavel.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (modeloDb == null) return NotFound();

            modeloDb.Nome = model.Nome;
            modeloDb.Email = model.Email;
            modeloDb.Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha);
            modeloDb.TipoUsuario = model.TipoUsuario;

            _context.Responsavel.Update(modeloDb);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Responsavel.FindAsync(id);

            if (model == null) return NotFound();

            _context.Responsavel.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private void GerarLinks(Responsavel model)
        {
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "self", metodo: "GET"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "update", metodo: "PUT"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "delete", metodo: "DELETE"));
        }
    }
}
