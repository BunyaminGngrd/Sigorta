using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaskoController : ControllerBase
    {
        private readonly SigortaIslemleriContext _dbContext;

        public KaskoController(SigortaIslemleriContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET: api/SigortaIslemleri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kasko>>> GetKasko()
        {
            if (_dbContext.Kasko == null)
            {
                return NotFound();
            }
            return await _dbContext.Kasko.ToListAsync();

        }
        //GET: api/Kasko/5
        [HttpGet("{PolId}")]
        public async Task<ActionResult<Kasko>> GetKasko(int id)
        {

            if (_dbContext.Kasko == null)
            {
                return NotFound();
            }
            var Kasko = await _dbContext.Kasko.FindAsync(id);

            if (Kasko == null)
            {
                return NotFound();
            }
            return Kasko;
        }

        //POST: api/Kasko
        [HttpPost]
        public async Task<ActionResult<Kasko>> PostSigortaIslemleri(Kasko Kasko)
        {
            _dbContext.Kasko.Add(Kasko);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetKasko), new { id = Kasko.PolId }, Kasko);

        }



        //PUT: api/Movies/5
        [HttpPut("{PolId}")]
        public async Task<IActionResult> PutSigortaIslemleri(int id, Kasko Kasko)
        {

            if (id != Kasko.PolId)
            {
                return BadRequest();
            }
            _dbContext.Entry(Kasko).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();

            }

            catch (DbUpdateConcurrencyException)
            {
                if (!KaskoExists(id))
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

        //Delete: api/sigortaislemleri/5
        [HttpDelete("{PolId}")]
        public async Task<IActionResult> DeleteKasko(int id)
        {
            if (_dbContext.Kasko == null)
            {
                return NotFound();
            }
            var Kasko = await _dbContext.Kasko.FindAsync(id);
            if (Kasko == null)
            {
                return NotFound();

            }
            _dbContext.Kasko.Remove(Kasko);
            await _dbContext.SaveChangesAsync();
            return NoContent();
            {

            }
        }









        private bool KaskoExists(long id)
        {
            return (_dbContext.Kasko?.Any(e => e.PolId == id)).GetValueOrDefault();
        }

    }
}
