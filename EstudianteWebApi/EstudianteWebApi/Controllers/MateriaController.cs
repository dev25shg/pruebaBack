using DataBase;
using EstudianteWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstudianteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private IServiceMateria _service;

        public MateriaController (IServiceMateria service)
        {
            _service = service;
        }


        [HttpGet]
        public ActionResult<List<Materia>> Get() 
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<Materia> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] Materia entity) {
            try
            {
                _service.Save(entity);
                return Ok(1);
            }
            catch (Exception ex)
            {

                return Ok(2);
            }
        }

        [HttpPut]
        public ActionResult<int> Put([FromBody] Materia entity, int id) {
            try
            {
                _service.Update(id, entity);
                return Ok(1);
            }
            catch (Exception ex)
            {

                return Ok(2);
            }
        }

    }
}
