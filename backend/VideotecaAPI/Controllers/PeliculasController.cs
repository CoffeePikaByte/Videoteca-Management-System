using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideotecaAPI.Data;
using VideotecaAPI.DTOs;

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
        public async Task<ActionResult<IEnumerable<PeliculaListadoDTO>>> ObtenerPeliculas()
        { 
            var peliculas =  await _context.Peliculas
                .Include(p => p.PeliculaGeneros)
                .ThenInclude(pg => pg.Genero)
                .Select(p => new PeliculaListadoDTO
                {
                    Id = p.Id,
                    Titulo = p.Titulo,
                    DuracionMin = p.DuracionMin,
                    Generos = p.PeliculaGeneros
                               .Select(p => p.Genero.Nombre)
                               .ToList()


                }).ToListAsync();
        
            return Ok(peliculas);
        }
    }
}
