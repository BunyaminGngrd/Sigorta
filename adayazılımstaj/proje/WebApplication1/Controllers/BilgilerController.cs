using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilgilerController : ControllerBase
    {
        private readonly SigortaIslemleriContext _dbContext;

        public BilgilerController(SigortaIslemleriContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET: api/SigortaIslemleri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SigortaIslemleri>>> GetBilgiler()
        {
            if (_dbContext.Bilgiler == null)
            {
                return NotFound();
            }
            return await _dbContext.Bilgiler.ToListAsync();

        }

        //GET: api/Bilgiler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SigortaIslemleri>> GetSigortaIslemleri(int id)
        {

            if (_dbContext.Bilgiler == null)
            {
                return NotFound();
            }
            var sigortaislemleri = await _dbContext.Bilgiler.FindAsync(id);

            if (sigortaislemleri==null)
            {
                return NotFound();
            }
            return sigortaislemleri;
        }

        //POST: api/Bilgiler
        [HttpPost]
        public async Task<ActionResult<SigortaIslemleri>> PostSigortaIslemleri(SigortaIslemleri sigortaislemleri)
        {
            _dbContext.Bilgiler.Add(sigortaislemleri);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSigortaIslemleri), new { id = sigortaislemleri.Id }, sigortaislemleri);

        }



        //PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSigortaIslemleri(int id, SigortaIslemleri sigortaislemleri)
        {

            if (id != sigortaislemleri.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(sigortaislemleri).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();

            }

            catch(DbUpdateConcurrencyException)
            {
                if (!SigortaIslemleriExists(id))
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSigortaIslemleri(int id)
        {
            if (_dbContext.Bilgiler==null)
            {
                return NotFound();
            }
            var sigortaislemleri = await _dbContext.Bilgiler.FindAsync(id);
            if (sigortaislemleri==null)
            {
                return NotFound();

            }
            _dbContext.Bilgiler.Remove(sigortaislemleri);
            await _dbContext.SaveChangesAsync();
            return NoContent();
            {
                
            }
        }


        [HttpGet("{name}/{password}")]
        public async Task<ActionResult<SigortaIslemleri>> LoginSigortaIslemleri(string name, string password)
        {
            if(name is not null && password is not null)
            {
                var sigortaislemleri = await _dbContext.Bilgiler.Where(x => x.Name!.ToLower().Equals(name.ToLower()) && x.Password==password).FirstOrDefaultAsync();
  
                    return sigortaislemleri != null ? Ok(sigortaislemleri): NotFound("User Not Found");
                
            }
            return BadRequest("Invalid Request");


        }






        private bool SigortaIslemleriExists(long id)
        {
            return (_dbContext.Bilgiler?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
