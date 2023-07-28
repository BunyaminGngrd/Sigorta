using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaglikController : ControllerBase
    {
        private readonly SigortaIslemleriContext _dbContext;

        public SaglikController(SigortaIslemleriContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET: api/SigortaIslemleri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saglik>>> GetSaglik()
        {
            if (_dbContext.Saglik == null)
            {
                return NotFound();
            }
            return await _dbContext.Saglik.ToListAsync();

        }
        //GET: api/Saglik/5
        [HttpGet("{PolId}")]
        public async Task<ActionResult<Saglik>> GetSaglik(int id)
        {

            if (_dbContext.Saglik == null)
            {
                return NotFound();
            }
            var Saglik = await _dbContext.Saglik.FindAsync(id);

            if (Saglik == null)
            {
                return NotFound();
            }
            return Saglik;
        }

        //POST: api/Saglik
        [HttpPost]
        public async Task<ActionResult<Saglik>> PostSigortaIslemleri(Saglik Saglik)
        {
            _dbContext.Saglik.Add(Saglik);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSaglik), new { id = Saglik.PolId }, Saglik);

        }



        //PUT: api/Movies/5
        [HttpPut("{PolId}")]
        public async Task<IActionResult> PutSigortaIslemleri(int id, Saglik Saglik)
        {

            if (id != Saglik.PolId)
            {
                return BadRequest();
            }
            _dbContext.Entry(Saglik).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();

            }

            catch (DbUpdateConcurrencyException)
            {
                if (!SaglikExists(id))
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
        public async Task<IActionResult> DeleteSaglik(int id)
        {
            if (_dbContext.Saglik == null)
            {
                return NotFound();
            }
            var Saglik = await _dbContext.Saglik.FindAsync(id);
            if (Saglik == null)
            {
                return NotFound();

            }
            _dbContext.Saglik.Remove(Saglik);
            await _dbContext.SaveChangesAsync();
            return NoContent();
            {

            }
        }









        private bool SaglikExists(long id)
        {
            return (_dbContext.Saglik?.Any(e => e.PolId == id)).GetValueOrDefault();
        }

    }
}
