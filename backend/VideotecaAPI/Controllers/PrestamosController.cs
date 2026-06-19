using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideotecaAPI.Data;
using VideotecaAPI.DTOs;
using VideotecaAPI.Models;

namespace VideotecaAPI.DTOs
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly VideotecaContext _context;

        public PrestamosController(VideotecaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrestamoListadoDTO>>> ObtenerPrestammos()
        {
            var prestamos = await _context.Prestamos
                .Include(p => p.cliente)
                .ThenInclude(c => c.persona)
                .Select(p => new PrestamoListadoDTO
                {
                    Id = p.Id,
                    FechaPrestamo = p.FechaPrestamo,
                    FechaDevolucion = p.FechaLimiteDevolucion,
                    NombreCliente = p.cliente.persona.Nombre,
                    CodigoFacturacion = p.CodigoFacturacion,
                    Estado = p.Estado
                })
                .ToListAsync();


            return Ok(prestamos);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrestamoDetallesDTO>> ObtenerPrestamoPorID(int id)
        {
            var prestamo = await _context.Prestamos
                .Include(p => p.cliente)
                .ThenInclude(c => c.persona)
                .Include(p => p.sucursal)
                .Include(p => p.encargado)
                .ThenInclude(e => e.Persona)
                .FirstOrDefaultAsync(p => p.Id == id);


            if (prestamo == null)
            {
                return NotFound();
            }

            var prestamoDetallesDTO = new PrestamoDetallesDTO
            {
                Id = prestamo.Id,
                CodigoFacturacion = prestamo.CodigoFacturacion,
                NombreCliente = prestamo.cliente.persona.Nombre,
                NombreEncargado = prestamo.encargado.Persona.Nombre,
                NombreSucursal = prestamo.sucursal.Nombre,
                FechaPrestamo = prestamo.FechaPrestamo,
                FechaLimiteDevolucion = prestamo.FechaLimiteDevolucion,
                Estado = prestamo.Estado,
                Peliculas = await _context.DetallesPrestamo
                    .Where(dp => dp.IdPrestamo == prestamo.Id)
                    .Include(dp => dp.Pelicula)
                    .Select(dp => new PeliculasPrestamoDTO
                    {
                        IdPelicula = dp.IdPelicula,
                        Titulo = dp.Pelicula.Titulo,
                        Cantidad = dp.CantidadPelicula
                    })
                    .ToListAsync()
            };

            return Ok(prestamoDetallesDTO);

        }

        [HttpPost]
        public async Task<ActionResult> CrearPrestamo(PrestamoCrearDTO prestamoCrearDTO)
        {
            var prestamo = new Prestamo
            {
                CodigoFacturacion = prestamoCrearDTO.CodigoFacturacion,
                FechaPrestamo = prestamoCrearDTO.FechaPrestamo,
                FechaLimiteDevolucion = prestamoCrearDTO.FechaLimiteDevolucion,
                Estado = prestamoCrearDTO.Estado,
                IdCliente = prestamoCrearDTO.IdCliente,
                IdEncargado = prestamoCrearDTO.IdEncargado,
                IdSucursal = prestamoCrearDTO.IdSucursal
            };
        
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            var detallesPrestamo = prestamoCrearDTO.Detalles
            .Select(dp => new DetallesPrestamo
            {
                IdPrestamo = prestamo.Id,
                IdPelicula = dp.IdPelicula,
                CantidadPelicula = dp.Cantidad
            }).ToList();

            Console.WriteLine($"Detalles creados: {detallesPrestamo.Count}");

            foreach(var d in detallesPrestamo)
            {
                Console.WriteLine($"Pelicula: {d.IdPelicula}");
            }

            Console.WriteLine($"Lista count: {detallesPrestamo.Count}");

            foreach (var d in detallesPrestamo)
            {
                Console.WriteLine(
                $"Hash: {d.GetHashCode()} | Prestamo: {d.IdPrestamo} | Pelicula: {d.IdPelicula}"
                );
            }

            _context.DetallesPrestamo.AddRange(detallesPrestamo);

            Console.WriteLine("TRACKER:");

            foreach (var item in _context.ChangeTracker.Entries<DetallesPrestamo>())
            {
                Console.WriteLine(
                $"Estado: {item.State} | Prestamo: {item.Entity.IdPrestamo} | Pelicula: {item.Entity.IdPelicula}"
                );
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerPrestamoPorID),
                                new { id = prestamo.Id },
                                prestamo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarPrestamo(int id, PrestamoCrearDTO prestamoCrearDTO)
        {
            var prestamoExistente = await _context.Prestamos
            .Include(p => p.cliente)
            .ThenInclude(c => c.persona)
            .Include(p => p.sucursal)
            .Include(p => p.encargado)
            .ThenInclude(e => e.Persona)
            .FirstOrDefaultAsync(p => p.Id == id);

            if (prestamoExistente == null)
            {
                return NotFound();
            }

            prestamoExistente.CodigoFacturacion = prestamoCrearDTO.CodigoFacturacion;
            prestamoExistente.FechaPrestamo = prestamoCrearDTO.FechaPrestamo;
            prestamoExistente.FechaLimiteDevolucion = prestamoCrearDTO.FechaLimiteDevolucion;
            prestamoExistente.Estado = prestamoCrearDTO.Estado;
            prestamoExistente.IdCliente = prestamoCrearDTO.IdCliente;
            prestamoExistente.IdEncargado = prestamoCrearDTO.IdEncargado;
            prestamoExistente.IdSucursal = prestamoCrearDTO.IdSucursal;

            var detallesExistentes = await _context.DetallesPrestamo
                .Where(dp => dp.IdPrestamo == id)
                .ToListAsync();

            _context.DetallesPrestamo.RemoveRange(detallesExistentes);

            var nuevosDetalles = prestamoCrearDTO.Detalles
                .Select(dp => new DetallesPrestamo
                {
                    IdPrestamo = id,
                    IdPelicula = dp.IdPelicula,
                    CantidadPelicula = dp.Cantidad
                }).ToList();

            _context.DetallesPrestamo.AddRange(nuevosDetalles);

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarPrestamo(int id)
        {
            var prestamo = await _context.Prestamos
            .Include(p => p.cliente)
            .ThenInclude(c => c.persona)
            .Include(p => p.sucursal)
            .Include(p => p.encargado)
            .ThenInclude(e => e.Persona)
            .FirstOrDefaultAsync(p => p.Id == id);

            if (prestamo == null)
            {
                return NotFound();
            }

            var detallesExistentes = await _context.DetallesPrestamo
                .Where(dp => dp.IdPrestamo == id)
                .ToListAsync();

            _context.DetallesPrestamo.RemoveRange(detallesExistentes);
            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();

            return NoContent();
        }



    }
}