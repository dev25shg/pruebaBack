using DataBase;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MySqlConnector;
using Dapper;

namespace EstudianteWebApi.Services
{

    public class ServicioDetalle : IservicioDetalle
    {
        private InstitutoContext _context;
        private readonly IConfiguration _config;
        public ServicioDetalle(InstitutoContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"))) {
                    var mate = await connection.ExecuteAsync("Delete from DetalleEstudiante where DetalleId = @Id", new { Id = id});
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DetalleEstudiante> Get()
        {
            try
            {
                using (var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"))) {
                var estudi = connection.Query<DetalleEstudiante>("Select * from DetalleEstudiante");
                return estudi.ToList();
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

      

        public async Task Save(DetalleEstudiante detest)
        {
            try
            {
                using (var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"))) 
                {
                    var mate = await connection.ExecuteAsync("Insert into DetalleEstudiante (MateriaId, EstudianteId) values (@mat, @est)", new { mat = detest.MateriaId, est= detest.EstudianteId});
                }               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(int id, DetalleEstudiante detest)
        {
            try
            {
                using (var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"))) {
                    var estu = await connection.ExecuteAsync("Update DetalleEstudiante Set MateriaId = @mid, EstudianteId = @eid where DetalleId = @Id", new { mid = detest.MateriaId, eid= detest.EstudianteId, Id =id});
                }               
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}
