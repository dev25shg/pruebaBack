using DataBase;

namespace EstudianteWebApi.Services
{
    public interface IServiceProfesor
    {
        IEnumerable<Profesor> Get();
        Profesor Get(int id);
        Task Save(Profesor profesor);
        Task Update(int id, Profesor profesor);
        Task Delete(int id);

    }
}
