using Matricula.BD.Data;
using Matricula.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Matricula.Shared;
namespace Matricula.Server.Controllers
{
    [ApiController]
    [Route("api/Especialidades")]
    public class EspecialidadesController : ControllerBase
    {
        private readonly dbcontext context;

        public EspecialidadesController(dbcontext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Especialidad>>> Get()
        {
            var resp = await context.Especialidades.ToListAsync();
            return resp;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Especialidad>> Get(int id)
        {
            var especialidad = await context.Especialidades
                                         .Where(e => e.Id == id)
                                         //.Include(m => m.Matriculas)
                                         .FirstOrDefaultAsync();
            if (especialidad == null)
            {
                return NotFound($"No existe la especialidad de Id={id}");
            }
            return especialidad;
        }

        [HttpGet("EspecialidadPorCodigo/{codigo}")]
        public async Task<ActionResult<Especialidad>> EspecialidadPorCodigo(string codigo)
        {
            var especialidad = await context.Especialidades
                                     .Where(e => e.Codigo == codigo)
                                     .FirstOrDefaultAsync();
            if (especialidad == null)
            {
                return NotFound($"No existe la especialidad de código={codigo}");
            }
            return especialidad;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Especialidad especialidad)
        {
            try
            {
                context.Especialidades.Add(especialidad);
                await context.SaveChangesAsync();
                return especialidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("MedicoEspecialidad")]
        public async Task<ActionResult<int>> MedicoEspecialidad(MedicoEspecialidadDTO medicoEspecialidadDTO)
        {
            try
            {
                Especialidad especialidad = new()
                {
                    Codigo = medicoEspecialidadDTO.Codigo,
                    NomEspecialidad = medicoEspecialidadDTO.NomEspecialidad
                };
                context.Especialidades.Add(especialidad);

                Medico medico = new()
                {
                    DNI = medicoEspecialidadDTO.DNI,
                    Nombre = medicoEspecialidadDTO.Nombre
                };
                context.Medicos.Add(medico);

                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Especialidad especialidad)
        {
            if(id != especialidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var pepe = context.Especialidades.Where(e => e.Id == id).FirstOrDefault();

            if(pepe == null)
            {
                return NotFound("No existe la especialidad a modificar");
            }

            pepe.Codigo = especialidad.Codigo;
            pepe.NomEspecialidad = especialidad.NomEspecialidad;

            try
            {
                //throw(new Exception("Cualquier Verdura"));
                context.Especialidades.Update(pepe);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var pepe = context.Especialidades.Where(x=>x.Id==id).FirstOrDefault();

            if(pepe==null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {
                context.Especialidades.Remove(pepe);
                context.SaveChanges();
                return Ok($"El registro de {pepe.NomEspecialidad} ha sido borrado.");
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no pudieron eliminarse por: {e.Message}");
            }
        }
    }
}
