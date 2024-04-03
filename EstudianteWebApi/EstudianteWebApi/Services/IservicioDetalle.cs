﻿using DataBase;

namespace EstudianteWebApi.Services
{
    public interface IservicioDetalle
    {
        IEnumerable<DetalleEstudiante> Get(int id);
        //DetalleEstudiante Get(int id);
        Task Save(DetalleEstudiante detest);
        Task Update(int id, DetalleEstudiante detest);
        Task Delete(int id);
    }
}
