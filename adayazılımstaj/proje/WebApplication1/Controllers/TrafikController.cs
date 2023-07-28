using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrafikController : ControllerBase
    {
        private readonly SigortaIslemleriContext _dbContext;

        public TrafikController(SigortaIslemleriContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET: api/SigortaIslemleri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trafik>>> GetTrafik()
        {
            if (_dbContext.Trafik == null)
            {
                return NotFound();
            }
            return await _dbContext.Trafik.ToListAsync();

        }
        //GET: api/Trafik/5
        [HttpGet("{PolId}")]
        public async Task<ActionResult<Trafik>> GetTrafik(int id)
        {

            if (_dbContext.Trafik == null)
            {
                return NotFound();
            }
            var Trafik = await _dbContext.Trafik.FindAsync(id);

            if (Trafik == null)
            {
                return NotFound();
            }
            return Trafik;
        }

        //POST: api/Trafik
        [HttpPost]
        public async Task<ActionResult<Trafik>> PostSigortaIslemleri(Trafik Trafik)
        {
            _dbContext.Trafik.Add(Trafik);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTrafik), new { id = Trafik.PolId }, Trafik);

        }



        //PUT: api/Movies/5
        [HttpPut("{PolId}")]
        public async Task<IActionResult> PutSigortaIslemleri(int id, Trafik Trafik)
        {

            if (id != Trafik.PolId)
            {
                return BadRequest();
            }
            _dbContext.Entry(Trafik).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();

            }

            catch (DbUpdateConcurrencyException)
            {
                if (!TrafikExists(id))
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
        public async Task<IActionResult> DeleteTrafik(int id)
        {
            if (_dbContext.Trafik == null)
            {
                return NotFound();
            }
            var Trafik = await _dbContext.Trafik.FindAsync(id);
            if (Trafik == null)
            {
                return NotFound();

            }
            _dbContext.Trafik.Remove(Trafik);
            await _dbContext.SaveChangesAsync();
            return NoContent();
            {

            }
        }









        private bool TrafikExists(long id)
        {
            return (_dbContext.Trafik?.Any(e => e.PolId == id)).GetValueOrDefault();
        }

    }
}
