using DataBase;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MySqlConnector;
using Dapper;

namespace EstudianteWebApi.Services
{
    public class ServicioEstudiante : IServiceEstudiante
    {
        
        private readonly IConfiguration _config;
        public ServicioEstudiante(IConfiguration config)
        {            
            _config =config;
        }
        public async Task Delete(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"))) {
                    var mate = await connection.ExecuteAsync("Delete from Estudiante where EstudianteId = @Id", new { Id = id});
                }
                
             
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Estudiante> Get()
        {
            try
            {
                using (var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"))) {
                var estudi = connection.Query<Estudiante>("Select * from Estudiante");
                return estudi.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Estudiante Get(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"))) {
                var estud = connection.Query<Estudiante>("Select * from Estudiante where EstudianteId = @mId ", new { mId = id});

           
                if (estud != null)
                    return estud.FirstOrDefault();
                else
                    return new Estudiante();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Login(string correo, string password)
        {
            try
            {
                using (var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"))) {
                int estud = connection.ExecuteScalar<int>("Select count(*) from Estudiante where Correo = @Correo and Password = @Pass", new { Correo = correo, Pass= password});    
                 if (estud>0) 
                 return true;
                 else
                 return false;               
                }          
                    
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task Save(Estudiante estudiante)
        {
            try
            {
                using (var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"))) {
                    var mate = await connection.ExecuteAsync("Insert into Estudiante (Nombre, Correo, Password) values (@Nombre, @Correo, @Password)", new { Nombre = estudiante.Nombre, Correo= estudiante.Correo, Password=estudiante.Password});
                }
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(int id, Estudiante estudiante)
        {
            try
            {
                using (var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"))) {
                    var estu = await connection.ExecuteAsync("Update Estudiante Set Nombre = @Nombre, Correo = @Correo, Password= @Pass where EstudianteId = @Id", new { Nombre = estudiante.Nombre, Correo= estudiante.Correo, Pass= estudiante.Password, Id =id});
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Valida(int idestudiante, int idmateria)
        {
            try
            {
                
                using (var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"))) {
                    int estud = connection.ExecuteScalar<int>("Select count(*) from DetalleEstudiante as d, Materias as m where d.EstudianteId = @eid and d.MateriaId = m.MateriaId and m.ProfesorId IN (select p.ProfesorId from Materia as m, Profesor as p where m.MateriaId = @mid and m.ProfesorId = p.ProfesorId ) ", new { eid = idestudiante, mid= idmateria});    
                    if (estud>0)
                    return false;
                    else
                    return true;
                }
                       


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
