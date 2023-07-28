using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceController : ControllerBase
    {
        private readonly SigortaIslemleriContext _dbContext;

        public PoliceController(SigortaIslemleriContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET: api/SigortaIslemleri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoliceModel>>> GetPoliceler()
        {
            if (_dbContext.Policeler == null)
            {
                return NotFound();
            }
            return await _dbContext.Policeler.ToListAsync();

        }
        //GET: api/Policeler/5
        [HttpGet("{PoliceId}")]
        public async Task<ActionResult<PoliceModel>> GetPoliceModel(int id)
        {

            if (_dbContext.Policeler == null)
            {
                return NotFound();
            }
            var policemodel = await _dbContext.Policeler.FindAsync(id);

            if (policemodel == null)
            {
                return NotFound();
            }
            return policemodel;
        }

        //POST: api/Policeler
        [HttpPost]
        public async Task<ActionResult<PoliceModel>> PostSigortaIslemleri(PoliceModel policemodel)
        {
            _dbContext.Policeler.Add(policemodel);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPoliceModel), new { id = policemodel.PoliceId }, policemodel);

        }



        //PUT: api/Movies/5
        [HttpPut("{PoliceId}")]
        public async Task<IActionResult> PutSigortaIslemleri(int id, PoliceModel policemodel)
        {

            if (id != policemodel.PoliceId)
            {
                return BadRequest();
            }
            _dbContext.Entry(policemodel).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();

            }

            catch (DbUpdateConcurrencyException)
            {
                if (!PoliceModelExists(id))
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
        [HttpDelete("{PoliceId}")]
        public async Task<IActionResult> DeleteSigortaIslemleri(int PoliceId)
        {
            if (_dbContext.Policeler == null)
            {
                return NotFound();
            }
            var policemodel = await _dbContext.Policeler.FindAsync(PoliceId);
            if (policemodel == null)
            {
                return NotFound();

            }
            _dbContext.Policeler.Remove(policemodel);
            await _dbContext.SaveChangesAsync();
            return NoContent();
            {

            }
        }









        private bool PoliceModelExists(long id)
        {
            return (_dbContext.Policeler?.Any(e => e.PoliceId == id)).GetValueOrDefault();
        }

    }
}
