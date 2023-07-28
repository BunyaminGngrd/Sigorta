using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaskController : ControllerBase
    {
        private readonly SigortaIslemleriContext _dbContext;

        public DaskController(SigortaIslemleriContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET: api/SigortaIslemleri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dask>>> GetDask()
        {
            if (_dbContext.Dask == null)
            {
                return NotFound();
            }
            return await _dbContext.Dask.ToListAsync();

        }
        //GET: api/Dask/5
        [HttpGet("{PolId}")]
        public async Task<ActionResult<Dask>> GetDask(int id)
        {

            if (_dbContext.Dask == null)
            {
                return NotFound();
            }
            var Dask = await _dbContext.Dask.FindAsync(id);

            if (Dask == null)
            {
                return NotFound();
            }
            return Dask;
        }

        //POST: api/Dask
        [HttpPost]
        public async Task<ActionResult<Dask>> PostSigortaIslemleri(Dask Dask)
        {
            _dbContext.Dask.Add(Dask);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDask), new { id = Dask.PolId }, Dask);

        }



        //PUT: api/Movies/5
        [HttpPut("{PolId}")]
        public async Task<IActionResult> PutSigortaIslemleri(int id, Dask Dask)
        {

            if (id != Dask.PolId)
            {
                return BadRequest();
            }
            _dbContext.Entry(Dask).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();

            }

            catch (DbUpdateConcurrencyException)
            {
                if (!DaskExists(id))
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
        public async Task<IActionResult> DeleteDask(int id)
        {
            if (_dbContext.Dask == null)
            {
                return NotFound();
            }
            var Dask = await _dbContext.Dask.FindAsync(id);
            if (Dask == null)
            {
                return NotFound();

            }
            _dbContext.Dask.Remove(Dask);
            await _dbContext.SaveChangesAsync();
            return NoContent();
            {

            }
        }









        private bool DaskExists(long id)
        {
            return (_dbContext.Dask?.Any(e => e.PolId == id)).GetValueOrDefault();
        }

    }
}
