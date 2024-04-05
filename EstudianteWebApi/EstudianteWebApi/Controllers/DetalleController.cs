using DataBase;
using EstudianteWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EstudianteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleController : ControllerBase
    {
        private IservicioDetalle _servicio;

        public DetalleController (IservicioDetalle service)
        {
            _servicio = service;
        }

        [HttpGet]
        public IEnumerable<DetalleEstudiante> Get() {
            
            return _servicio.Get();
        }

         [HttpPost]
        public ActionResult Post([FromBody] DetalleEstudiante detest) {
            try
            {
                _servicio.Save(detest);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] DetalleEstudiante detestu, int id)
        {
            try
            {
                _servicio.Update(id, detestu);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _servicio.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}