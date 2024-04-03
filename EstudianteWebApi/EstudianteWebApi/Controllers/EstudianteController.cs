using DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstudianteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private InstitutoContext _context;

        public EstudianteController(InstitutoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Estudiante> Get() => _context.Estudiantes.ToList();


    }
}
