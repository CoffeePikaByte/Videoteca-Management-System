using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideotecaAPI.Data;
using VideotecaAPI.DTOs;
using VideotecaAPI.Models;

namespace VideotecaAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly VideotecaContext _context;

        public ClienteController(VideotecaContext context)
        {
            _context = context;
        }

        // Aquí puedes agregar métodos para manejar las operaciones CRUD de los clientes

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> ObtenerClientes()
        {
            var clientes = await _context.Clientes
                                .Include(c => c.persona)
                                .Select(c => new ClienteListadoDTO
                                {
                                    Id = c.Id,
                                    DocumentoIdentidad = c.persona.DocumentoIdentidad,
                                    CodigoCliente = c.Identificacion,
                                    Nombre = c.persona.Nombre,
                                    PrimerApellido = c.persona.PrimerApellido,
                                    SegundoApellido = c.persona.SegundoApellido,
                                    Activo = c.Activo
                                }).ToListAsync();


            
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> ObtenerClientePorId(int id)
        {
            var cliente = await _context.Clientes
                                .Include(c => c.persona)
                                .ThenInclude(p => p.Direcciones)
                                .Include(c => c.persona)
                                .ThenInclude(p => p.Telefono)
                                .FirstOrDefaultAsync(c => c.Id == id);


            if (cliente == null)
            {
                return NotFound();
            }

            var clienteDTO = new ClienteDetallesDTO
            {
                Id = cliente.Id,
                DocumentoIdentidad = cliente.persona.DocumentoIdentidad,
                CodigoCliente = cliente.Identificacion,
                Nombre = cliente.persona.Nombre,
                PrimerApellido = cliente.persona.PrimerApellido,
                SegundoApellido = cliente.persona.SegundoApellido,
                FechaNacimiento = cliente.persona.FechaNacimiento,
                FechaRegistro = cliente.FechaRegisto,
                Activo = cliente.Activo,
                Direccion = cliente.persona.Direcciones.Provincia
                             + " " + cliente.persona.Direcciones.Canton 
                             + ", " + cliente.persona.Direcciones.Distrito,
                Telefono = cliente.persona.Telefono.Numero
            };

            return Ok(clienteDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CrearCliente(ClienteCrearDTO clienteDTO)
        {
            var cliente = new Cliente
            {
                Identificacion = clienteDTO.CodigoCliente,
                FechaRegisto = DateTime.Now,
                Activo = true,
                persona = new Persona
                {
                    DocumentoIdentidad = clienteDTO.DocumentoIdentidad,
                    Nombre = clienteDTO.Nombre,
                    PrimerApellido = clienteDTO.PrimerApellido,
                    SegundoApellido = clienteDTO.SegundoApellido,
                    FechaNacimiento = clienteDTO.FechaNacimiento,
                    Direcciones = new Direccion
                    {
                        Pais = clienteDTO.pais,
                        Provincia = clienteDTO.Provincia,
                        Canton = clienteDTO.Canton,
                        Distrito = clienteDTO.Distrito,
                        IndicacionesAdiccionales = clienteDTO.IndicacionesAdiccionales
                    },
                    Telefono = new Telefono
                    {
                        Numero = clienteDTO.Telefono
                    }
                }
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(ObtenerClientePorId),
                new { id = cliente.Id }, cliente);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarCliente(int id, ClienteCrearDTO clienteDTO)
        {
            var clienteExistente = await _context.Clientes
                                        .Include(c => c.persona)
                                        .ThenInclude(p => p.Direcciones)
                                        .Include(c => c.persona)
                                        .ThenInclude(p => p.Telefono)
                                        .FirstOrDefaultAsync(c => c.Id == id);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            clienteExistente.Identificacion = clienteDTO.CodigoCliente;
            clienteExistente.persona.DocumentoIdentidad = clienteDTO.DocumentoIdentidad;
            clienteExistente.persona.Nombre = clienteDTO.Nombre;
            clienteExistente.persona.PrimerApellido = clienteDTO.PrimerApellido;
            clienteExistente.persona.SegundoApellido = clienteDTO.SegundoApellido;
            clienteExistente.persona.FechaNacimiento = clienteDTO.FechaNacimiento;
            clienteExistente.persona.Direcciones.Pais = clienteDTO.pais;
            clienteExistente.persona.Direcciones.Provincia = clienteDTO.Provincia;
            clienteExistente.persona.Direcciones.Canton = clienteDTO.Canton;
            clienteExistente.persona.Direcciones.Distrito = clienteDTO.Distrito;
            clienteExistente.persona.Direcciones.IndicacionesAdiccionales = clienteDTO.IndicacionesAdiccionales;
            clienteExistente.persona.Telefono.Numero = clienteDTO.Telefono;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarCliente(int id)
        {
            var cliente = await _context.Clientes
                                    .Include(c => c.persona)
                                    .ThenInclude(p => p.Direcciones)
                                    .Include(c => c.persona)
                                    .ThenInclude(p => p.Telefono)
                                    .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }
            
            _context.Personas.Remove(cliente.persona);
            _context.Direcciones.Remove(cliente.persona.Direcciones);
            _context.Telefonos.Remove(cliente.persona.Telefono);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    
    }
    
}