using DataBase;
using Microsoft.EntityFrameworkCore;

namespace EstudianteWebApi.Services
{
    public class ServicioMateria : IServiceMateria
    {
        private InstitutoContext _context;
        public ServicioMateria(InstitutoContext context)
        {
            _context = context;
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

        public IEnumerable<Materia> Get()
        {
            try
            {
                return _context.Materias.ToList();
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
                var det = _context.Materias.Find(id);
                if (det != null)
                    return det;
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
                _context.Materias.Add(materia);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(int id, Materia materia)
        {
            try
            {
                var mat = _context.Materias.Find(id);
                if (mat != null)
                {
                    mat.Nombre = materia.Nombre;
                    mat.ProfesorId = materia.ProfesorId;
                    mat.Profesor = materia.Profesor;

                    //prof. = profesor.Nombre;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
