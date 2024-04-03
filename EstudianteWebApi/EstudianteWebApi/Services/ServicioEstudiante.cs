using DataBase;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EstudianteWebApi.Services
{
    public class ServicioEstudiante : IServiceEstudiante
    {
        private InstitutoContext _context;
        public ServicioEstudiante(InstitutoContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var est = _context.Estudiantes.Find(id);
                if (est != null)
                {
                    _context.Estudiantes.Remove(est);

                    await _context.SaveChangesAsync();
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
                return _context.Estudiantes;
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
                var est = _context.Estudiantes.Find(id);
                if (est != null)
                    return est;
                else
                    return new Estudiante();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Save(Estudiante estudiante)
        {
            try
            {
                _context.Estudiantes.Add(estudiante);
                await _context.SaveChangesAsync();

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
                var est = _context.Estudiantes.Find(id);
                if (est != null)
                {
                    est.Nombre = estudiante.Nombre;
                    est.Correo = estudiante.Correo;
                    est.Password = estudiante.Password;
                    
                    //prof. = profesor.Nombre;
                    await _context.SaveChangesAsync();
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
                //var profes = _context.Profesores.Where(q => q.)
                var vali = true;
                var detestu = _context.DetalleEstudiantes
                    .Where(b => b.EstudianteId == idestudiante);
                if (detestu != null)
                {
                    foreach (var est in detestu)
                    {
                        var profes = _context.Materias
                            .Where(q => q.MateriaId == idmateria && q.ProfesorId == est.Materia.ProfesorId).Count();
                        if (profes > 0)
                            vali = false;
                    }
                }
                return vali; 


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
