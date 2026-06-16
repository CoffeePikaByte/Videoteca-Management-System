using Microsoft.AspNetCore.Mvc;
using VideotecaAPI.DTOs;
using VideotecaAPI.Models;
using VideotecaAPI.Data;
using Microsoft.EntityFrameworkCore;


namespace VideotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly VideotecaContext _context;

        public SucursalesController(VideotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SucursalListadoDTO>>> ObtenerSucursales()
        {
            var sucursales = await _context.Sucursales
                .Select(s => new SucursalListadoDTO
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    pais = s.Direccion.Pais,
                    provincia = s.Direccion.Provincia,
                    telefono = s.Telefono.Numero,
                    Estado = s.Estado
                }).ToListAsync();

            return Ok(sucursales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SucursalDetallesDTO>> ObtenerSucursalPorId(int id)
        {
            var sucursal = await _context.Sucursales
                .Include(s => s.Direccion)
                .Include(s => s.Telefono)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sucursal == null)
            {
                return NotFound();
            }

            var sucursalDTO = new SucursalDetallesDTO
            {
                Id = sucursal.Id,
                Nombre = sucursal.Nombre,
                Pais = sucursal.Direccion.Pais,
                Provincia = sucursal.Direccion.Provincia,
                Canton = sucursal.Direccion.Canton,
                Distrito = sucursal.Direccion.Distrito,
                IndicacionesAdicionales = sucursal.Direccion.IndicacionesAdiccionales,
                Telefono = sucursal.Telefono.Numero,
                Estado = sucursal.Estado
            };

            return Ok(sucursalDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CrearSucursal(SucursalCrearDTO sucursalCrearDTO)
        {
            var sucursal = new Sucursal
            {
                Nombre = sucursalCrearDTO.Nombre,
                Direccion = new Direccion
                {
                    Pais = sucursalCrearDTO.Pais,
                    Provincia = sucursalCrearDTO.Provincia,
                    Canton = sucursalCrearDTO.Canton,
                    Distrito = sucursalCrearDTO.Distrito,
                    IndicacionesAdiccionales = sucursalCrearDTO.IndicacionesAdicionales
                },
                Telefono = new Telefono
                {
                    Numero = sucursalCrearDTO.Telefono
                },
                Estado = sucursalCrearDTO.Estado
            };

            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerSucursalPorId),
             new { id = sucursal.Id }, sucursal);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarSucursal(int id, SucursalCrearDTO sucursalCrearDTO)
        {
            var sucursal = await _context.Sucursales
                .Include(s => s.Direccion)
                .Include(s => s.Telefono)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sucursal == null)
            {
                return NotFound();
            }

            sucursal.Nombre = sucursalCrearDTO.Nombre;
            sucursal.Direccion.Pais = sucursalCrearDTO.Pais;
            sucursal.Direccion.Provincia = sucursalCrearDTO.Provincia;
            sucursal.Direccion.Canton = sucursalCrearDTO.Canton;
            sucursal.Direccion.Distrito = sucursalCrearDTO.Distrito;
            sucursal.Direccion.IndicacionesAdiccionales = sucursalCrearDTO.IndicacionesAdicionales;
            sucursal.Telefono.Numero = sucursalCrearDTO.Telefono;
            sucursal.Estado = sucursalCrearDTO.Estado;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarSucursal(int id)
        {
            var sucursal = await _context.Sucursales
            .Include(s => s.Direccion)
            .Include(s => s.Telefono)
            .FirstOrDefaultAsync(s => s.Id == id);

            if (sucursal == null)
            {
                return NotFound();
            }

            _context.Direcciones.Remove(sucursal.Direccion);
            _context.Telefonos.Remove(sucursal.Telefono);
            _context.Sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}