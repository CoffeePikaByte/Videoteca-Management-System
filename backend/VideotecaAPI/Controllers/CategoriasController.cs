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
    public class CategoriasController : ControllerBase
    {
        private readonly VideotecaContext _context;

        public CategoriasController(VideotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaListadoDTO>>> ObtenerCategorias()
        {
            var categorias = await _context.Categorias
                .Select(c => new CategoriaListadoDTO
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    EdadMinima = c.EdadMinima
                }).ToListAsync();

            return Ok(categorias);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDetallesDTO>> ObtenerCategoriaPorId(int id)
        {  
            var categoria = await _context.Categorias
                .Include(c => c.Peliculas)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            var categoriaDTO = new CategoriaDetallesDTO
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                EdadMinima = categoria.EdadMinima,
                Peliculas = categoria.Peliculas.Select(p => new PeliculaDetallesDTO
                {
                    Id = p.Id,
                    Titulo = p.Titulo,
                    DuracionMin = p.DuracionMin
                }).ToList()
            };

            return Ok(categoriaDTO);

        }

        [HttpPost]
        public async Task<ActionResult> CrearCategoria(CategoriaCrearDTO categoriaDTO)
        {
            var categoria = new Categoria
            {
                Nombre = categoriaDTO.Nombre,
                EdadMinima = categoriaDTO.EdadMinima
            };

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerCategoriaPorId),
             new { id = categoria.Id },
              categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarCategoria(int id, CategoriaCrearDTO categoriaDTO)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.Nombre = categoriaDTO.Nombre;
            categoria.EdadMinima = categoriaDTO.EdadMinima;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarCategoria(int id)
        {
            var categoria = await _context.Categorias
            .Include(c => c.Peliculas)
            .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            _context.Peliculas.RemoveRange(categoria.Peliculas);
            _context.Categorias.Remove(categoria);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}