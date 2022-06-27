using Matricula.BD.Data;
using Matricula.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return await context.Especialidades.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Especialidad>> Get(int id)
        {
            var especialidad = await context.Especialidades
                                         .Where(e => e.Id == id)
                                         .Include(m => m.Matriculas)
                                         .FirstOrDefaultAsync();
            if (especialidad == null)
            {
                return NotFound($"No existe la especialidad de Id={id}");
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


        [HttpGet("EspecialidadPorCodigo/{codigo}")]
        public async Task<ActionResult<Especialidad>> EspecialidadPorCodigo(string codigo)
        {
            var especialidad = await context.Especialidades
                                     .Where(e => e.Codigo == codigo)
                                     .Include(m => m.Matriculas)
                                     .FirstOrDefaultAsync();
            if (especialidad == null)
            {
                return NotFound($"No existe la especialidad de código={codigo}");
            }
            return especialidad;
        }

    }
}
