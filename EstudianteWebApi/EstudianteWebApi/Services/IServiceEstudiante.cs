using DataBase;

namespace EstudianteWebApi.Services
{
    public interface IServiceEstudiante
    {
        IEnumerable<Estudiante> Get();
        Estudiante Get(int id);
        Task Save(Estudiante estudiante);
        Task Update(int id, Estudiante estudiante);
        Task Delete(int id);
        Boolean Valida(int idestudiante, int idmateria);
    }
}
