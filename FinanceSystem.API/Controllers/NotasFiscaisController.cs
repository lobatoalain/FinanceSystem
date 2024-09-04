using FinanceSystem.API.Dtos;
using FinanceSystem.Core.Entities;
using FinanceSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanceSystem.Core.Extensions;

namespace FinanceSystem.API.Controllers
{
    public class NotasFiscaisController : Controller
    {
        private readonly FinanceDbContext _context;
        public NotasFiscaisController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet("api/NotasFiscais")]
        public ActionResult<IEnumerable<NotaFiscalDto>> GetNotasFiscais()
        {
            var notas = _context.NotasFiscais.ToList();
            var notasDto = notas.Select(n => new NotaFiscalDto
            {
                Id = n.Id,
                Pagador = n.Pagador,
                NumeroNota = n.NumeroNota,
                DataEmissao = n.DataEmissao,
                DataCobranca = n.DataCobranca,
                DataPagamento = n.DataPagamento,
                ValorNota = n.ValorNota,
                DocumentoNotaFiscal = n.DocumentoNotaFiscal,
                DocumentoBoleto = n.DocumentoBoleto,
                Status = n.Status.GetDisplayName()
            });

            return Ok(notasDto);
        }

        [HttpGet("api/NotasFiscais/{id}")]
        public async Task<ActionResult<NotaFiscal>> GetNotaFiscal(int id)
        {
            var notaFiscal = await _context.NotasFiscais.FindAsync(id);

            if (notaFiscal == null)
            {
                return NotFound();
            }

            return notaFiscal;
        }

        [HttpPost("api/NotasFiscais")]
        public async Task<ActionResult<NotaFiscal>> PostNotaFiscal([FromBody] NotaFiscal notaFiscal)
        {
            _context.NotasFiscais.Add(notaFiscal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNotaFiscal), new { id = notaFiscal.Id }, notaFiscal);
        }

        [HttpPut("api/NotasFiscais/{id}")]
        public async Task<IActionResult> PutNotaFiscal(int id, [FromBody] NotaFiscal notaFiscal)
        {
            if (id != notaFiscal.Id)
            {
                return BadRequest();
            }

            _context.Entry(notaFiscal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaFiscalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("api/NotasFiscais/{id}")]
        public async Task<IActionResult> DeleteNotaFiscal(int id)
        {
            var notaFiscal = await _context.NotasFiscais.FindAsync(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }

            _context.NotasFiscais.Remove(notaFiscal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotaFiscalExists(int id)
        {
            return _context.NotasFiscais.Any(e => e.Id == id);
        }
    }
}
