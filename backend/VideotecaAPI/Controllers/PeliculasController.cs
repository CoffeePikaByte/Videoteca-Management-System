using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideotecaAPI.Data;
using VideotecaAPI.DTOs;
using VideotecaAPI.Models;

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
            var peliculas = await _context.Peliculas
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

        [HttpGet("{id}")]
        public async Task<ActionResult<PeliculaDetallesDTO>> ObtenerPeliculaPorId(int id)
        {
            var pelicula = await _context.Peliculas
                .Include(p => p.Categoria)
                .Include(p => p.PeliculaGeneros)
                .ThenInclude(pg => pg.Genero)
                .FirstOrDefaultAsync(p => p.Id == id);


            if (pelicula == null)
            {
                return NotFound();
            }

            var peliculaDTO = new PeliculaDetallesDTO
            {
                Id = pelicula.Id,
                Titulo = pelicula.Titulo,
                AnioLanzamiento = pelicula.AnioLanzamiento,
                Idioma = pelicula.Idioma,
                DuracionMin = pelicula.DuracionMin,

                Categoria = pelicula.Categoria.Nombre,
                EdadMinima = pelicula.Categoria.EdadMinima,

                Generos = pelicula.PeliculaGeneros
                .Select(pg => pg.Genero.Nombre)
                .ToList()

            };

            return Ok(peliculaDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CrearPelicula(PeliculaCrearDTO peliculaDTO)
        {
            var pelicula = new Pelicula
            {
                Titulo = peliculaDTO.Titulo,
                AnioLanzamiento = peliculaDTO.AnioLanzamiento,
                Idioma = peliculaDTO.Idioma,
                DuracionMin = peliculaDTO.DuracionMin,
                IdCategoria = peliculaDTO.IdCategoria

            };

            _context.Add(pelicula);
            await _context.SaveChangesAsync();

            pelicula.PeliculaGeneros = peliculaDTO.IdGeneros
                .Select(idGenero => new PeliculasGeneros
                {
                    IdGenero = idGenero,
                    IdPelicula = pelicula.Id

                }).ToList();

            return CreatedAtAction(
                nameof(ObtenerPeliculaPorId),
                new { id = pelicula.Id },
                pelicula);


        }


        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarPelicula(int id, PeliculaActualizarDTO peliculaActualizarDTO)
        {
            var pelicula = await _context.Peliculas
                .Include(p => p.PeliculaGeneros)
                .ThenInclude(pg => pg.Genero)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula == null)
            {
                return NotFound();
            }

            pelicula.Titulo = peliculaActualizarDTO.Titulo;
            pelicula.AnioLanzamiento = peliculaActualizarDTO.AnioLanzamiento;
            pelicula.Idioma = peliculaActualizarDTO.Idioma;
            pelicula.DuracionMin = peliculaActualizarDTO.DuracionMin;
            pelicula.IdCategoria = peliculaActualizarDTO.IdCategoria;
            pelicula.PeliculaGeneros.Clear();

            pelicula.PeliculaGeneros = peliculaActualizarDTO.IdGeneros
                .Select(idGenero => new PeliculasGeneros
                {
                    IdGenero = idGenero,
                    IdPelicula = pelicula.Id

                }).ToList();


            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarPelicula(int id)
        { 
            var pelicula = await _context.Peliculas
            .Include(p => p.PeliculaGeneros)
            .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula == null)
            {
                return NotFound();
            }

            _context.PeliculasGeneros.RemoveRange(pelicula.PeliculaGeneros);
            _context.Peliculas.Remove(pelicula);

            _context.SaveChanges();

            return NoContent();
            

        }

    }
}
