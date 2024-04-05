using Dapper;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Mysqlx;

namespace EstudianteWebApi.Services
{
    public class ServicioMateria : IServiceMateria
    {
        private InstitutoContext _context;
        private readonly IConfiguration _config;
        public ServicioMateria(InstitutoContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task Delete(int id)
        {
            try
            {
                var mate = _context.Materias.Find(id);
                if (mate != null)
                {
                    _context.Materias.Remove(mate);

                    await _context.SaveChangesAsync();
                    
                }
               
                   
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Materia> Get()
        {
            try
            {
                using var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"));
                var mate = connection.Query<Materia>("Select * from Materia");
                return mate.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Materia Get(int id)
        {
            try
            {
                using var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"));
                var mate = connection.Query<Materia>("Select * from Materia where MateriaId = @mId ", new { mId = id});

                //var d = _context.Materias.Find(id);
                if (mate != null)                 
                    return mate.FirstOrDefault();
                else
                    return new Materia();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Save(Materia materia)
        {
            
            try
            {
                using var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"));
                var mate = await connection.ExecuteAsync("Insert into Materia (Nombre, ProfesorId) values (@Nombre, @ProfesorId)", new { Nombre = materia.Nombre, ProfesorId= materia.ProfesorId});
               // _context.Materias.Add(materia);
                //await _context.SaveChangesAsync();
               
            }
            catch (Exception ex)
            {

                throw;
            } 
        }

        public async Task Update(int id, Materia materia)
        {
            try
            {
                using var connection = new MySqlConnection(_config.GetConnectionString("InstitutoConection"));
                var mate = await connection.ExecuteAsync("Update Materia Set Nombre = @Nombre, ProfesorId = @ProfesorId where MateriaId = @MateriaId", new { Nombre = materia.Nombre, ProfesorId= materia.ProfesorId, MateriaId= materia.MateriaId});
              /*  var mat = _context.Materias.Find(id);
                if (mat != null)
                {
                    mat.Nombre = materia.Nombre;
                    mat.ProfesorId = materia.ProfesorId;
                    mat.Profesor = materia.Profesor;

                    
                    await _context.SaveChangesAsync();
                    
                }*/
                                    
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
