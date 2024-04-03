using DataBase;

namespace EstudianteWebApi.Services
{
    public class ServiceProfesor : IServiceProfesor
    {
        private InstitutoContext _context;
        public ServiceProfesor(InstitutoContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var prof = _context.Profesores.Find(id);
                if (prof != null)
                {
                    _context.Profesores.Remove(prof);
                    
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Profesor> Get()
        {
            return _context.Profesores;
        }

        public Profesor Get(int id)
        {
            var profesor = _context.Profesores.Find(id);
            if (profesor != null)
                return profesor;
            else
                return new Profesor();
        }

        public async Task Save(Profesor profesor)
        {
            _context.Profesores.Add(profesor);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Profesor profesor)
        {

            var prof = _context.Profesores.Find(id);
            if (prof != null)
            {
                prof.Nombre = profesor.Nombre;
                //prof. = profesor.Nombre;
                await _context.SaveChangesAsync();
            }              
           
        }
    }
}
