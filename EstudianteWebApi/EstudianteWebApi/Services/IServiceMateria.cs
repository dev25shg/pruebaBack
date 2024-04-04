using DataBase;

namespace EstudianteWebApi.Services
{
    public interface IServiceMateria
    {
        List<Materia> Get();
        Materia Get(int id);
        Task Save(Materia materia);
        Task Update(int id, Materia materia);
        Task Delete(int id);
    }
}
