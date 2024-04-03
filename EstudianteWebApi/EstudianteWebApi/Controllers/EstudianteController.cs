using DataBase;
using EstudianteWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstudianteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {

        private IServiceEstudiante _service;

        public EstudianteController(IServiceEstudiante service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Estudiante> Get() => _service.Get();

        [HttpPost]
        public ActionResult Post([FromBody] Estudiante estu) {
            try
            {
                _service.Save(estu);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Estudiante estu, int id)
        {
            try
            {
                _service.Update(id, estu);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


    }
}
