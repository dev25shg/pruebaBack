using DataBase;
using Microsoft.EntityFrameworkCore;

namespace EstudianteWebApi.Services
{

    public class ServicioDetalle : IservicioDetalle
    {
        private InstitutoContext _context;
        public ServicioDetalle(InstitutoContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deta = _context.DetalleEstudiantes.Find(id);
                if (deta != null)
                {
                    _context.DetalleEstudiantes.Remove(deta);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DetalleEstudiante> Get(int id)
        {
            try
            {
                return _context.DetalleEstudiantes
                    .Where(d => d.EstudianteId == id).ToList();
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
                _context.DetalleEstudiantes.Add(detest);
                await _context.SaveChangesAsync();
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
                var det = _context.DetalleEstudiantes.Find(id);
                if (det != null)
                {
                    det.EstudianteId = detest.EstudianteId;
                    det.MateriaId = detest.MateriaId;
                    det.Estudiante = detest.Estudiante;
                    det.Materia = detest.Materia;
                    
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
