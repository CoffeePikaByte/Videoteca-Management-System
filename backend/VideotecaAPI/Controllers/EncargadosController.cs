using VideotecaAPI.Data;
using VideotecaAPI.DTOs;
using VideotecaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VideotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncargadosController : ControllerBase
    {
        private readonly VideotecaContext _context;

        public EncargadosController(VideotecaContext context)
        {
            _context = context;
        }

        // GET: api/Encargados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EncargadoListadoDTO>>> ObtenerEncargados()
        {
            var encargados = await _context.Encargados
                .Include(e => e.Persona)
                .Select(e => new EncargadoListadoDTO
                {
                    Id = e.Id,
                    DocumentoIdentidad = e.Persona.DocumentoIdentidad,
                    CodigoEncargado = e.CodigoIdentificacion,
                    Nombre = e.Persona.Nombre,
                    PrimerApellido = e.Persona.PrimerApellido,
                    SegundoApellido = e.Persona.SegundoApellido
                })
                .ToListAsync();

            return Ok(encargados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EncargadoDetallesDTO>> ObtenerEncargado(int id)
        {
            var encargado = await _context.Encargados
                .Include(e => e.Persona)
                .ThenInclude(p => p.Direcciones)
                .Include(e => e.Persona)
                .ThenInclude(p => p.Telefono)
                .Select(e => new EncargadoDetallesDTO
                {
                    Id = e.Id,
                    DocumentoIdentidad = e.Persona.DocumentoIdentidad,
                    CodigoEncargado = e.CodigoIdentificacion,
                    Nombre = e.Persona.Nombre,
                    PrimerApellido = e.Persona.PrimerApellido,
                    SegundoApellido = e.Persona.SegundoApellido,
                    FechaIngreso = e.FechaIngreso,
                    FechaNacimiento = e.Persona.FechaNacimiento,
                    Telefono = e.Persona.Telefono.Numero,
                    Pais = e.Persona.Direcciones.Pais,
                    Provincia = e.Persona.Direcciones.Provincia,
                    Canton = e.Persona.Direcciones.Canton,
                    Distrito = e.Persona.Direcciones.Distrito,
                    IndicacionesAdiccionales = e.Persona.Direcciones.IndicacionesAdiccionales
                })
                .FirstOrDefaultAsync(e => e.Id == id);

            if (encargado == null)
            {
                return NotFound();
            }

            return Ok(encargado);
        }

        [HttpPost]
        public async Task<ActionResult> CrearEncargado(EncargadoCrearDTO encargadoDTO)
        {
            var encargado = new Encargado
            {
                CodigoIdentificacion = encargadoDTO.CodigoEncargado,
                FechaIngreso = encargadoDTO.FechaIngreso,
                Persona = new Persona
                {
                    DocumentoIdentidad = encargadoDTO.DocumentoIdentidad,
                    Nombre = encargadoDTO.Nombre,
                    PrimerApellido = encargadoDTO.PrimerApellido,
                    SegundoApellido = encargadoDTO.SegundoApellido,
                    FechaNacimiento = encargadoDTO.FechaNacimiento,
                    Telefono = new Telefono
                    {
                        Numero = encargadoDTO.Telefono
                    },
                    Direcciones = new Direccion
                    {
                        Pais = encargadoDTO.Pais,
                        Provincia = encargadoDTO.Provincia,
                        Canton = encargadoDTO.Canton,
                        Distrito = encargadoDTO.Distrito,
                        IndicacionesAdiccionales = encargadoDTO.IndicacionesAdiccionales
                    }
                }   
            };

            _context.Encargados.Add(encargado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerEncargado), 
            new { id = encargado.Id }, null);


        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarEncargado(int id, EncargadoCrearDTO encargadoDTO)
        {
            var encargado = await _context.Encargados
                .Include(e => e.Persona)
                .ThenInclude(p => p.Direcciones)
                .Include(e => e.Persona)
                .ThenInclude(p => p.Telefono)
                .FirstOrDefaultAsync(e => e.Id == id)
            ;
            if (encargado == null)
            {
                return NotFound();
            }

            encargado.CodigoIdentificacion = encargadoDTO.CodigoEncargado;
            encargado.FechaIngreso = encargadoDTO.FechaIngreso;
            encargado.Persona.DocumentoIdentidad = encargadoDTO.DocumentoIdentidad;
            encargado.Persona.Nombre = encargadoDTO.Nombre;
            encargado.Persona.PrimerApellido = encargadoDTO.PrimerApellido;
            encargado.Persona.SegundoApellido = encargadoDTO.SegundoApellido;
            encargado.Persona.FechaNacimiento = encargadoDTO.FechaNacimiento;
            encargado.Persona.Telefono.Numero = encargadoDTO.Telefono;
            encargado.Persona.Direcciones.Pais = encargadoDTO.Pais;
            encargado.Persona.Direcciones.Provincia = encargadoDTO.Provincia;
            encargado.Persona.Direcciones.Canton = encargadoDTO.Canton;
            encargado.Persona.Direcciones.Distrito = encargadoDTO.Distrito;
            encargado.Persona.Direcciones.IndicacionesAdiccionales = encargadoDTO.IndicacionesAdiccionales;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarEncargado(int id)
        {
            var encargado = await _context.Encargados
                .Include(e => e.Persona)
                .ThenInclude(p => p.Direcciones)
                .Include(e => e.Persona)
                .ThenInclude(p => p.Telefono)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (encargado == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(encargado.Persona);
            _context.Direcciones.Remove(encargado.Persona.Direcciones);
            _context.Telefonos.Remove(encargado.Persona.Telefono);
            _context.Encargados.Remove(encargado);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}