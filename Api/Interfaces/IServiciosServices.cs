using Data.Entities;

namespace Api.Interfaces
{
    public interface IServiciosServices
    {
        Task<List<Servicios>> BuscarLista();

        Task<bool> Guardar(Servicios servicios);

        Task<bool> Eliminar(Servicios servicios);
    }
}