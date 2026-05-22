using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideotecaAPI.Data;

namespace VideotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly VideotecaContext _context;

        public PeliculasController(VideotecaContext context)
        { 
            _context = context;
        
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerPeliculas()
        { 
            var peliculas = await _context.Peliculas.ToListAsync();

            return Ok(peliculas);
            
        }
    }
}
