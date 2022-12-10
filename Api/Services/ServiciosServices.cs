using Api.Interfaces;
using Commons.Helpers;
using Data.Entities;
using Data.Managers;

namespace Api.Services
{
    public class ServiciosServices : IServiciosServices
    {
        private readonly ServiciosManager _manager;

        public ServiciosServices()
        {
            _manager = new ServiciosManager();
        }
        public async Task<List<Servicios>> BuscarLista()
        {
            try
            {
                return await _manager.BuscarLista();
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "Servicio", "BuscarLista");
                throw ex;
            }
        }

        public async Task<bool> Eliminar(Servicios servicio)
        {
            servicio.Activo = false;
            return await _manager.Eliminar(servicio);
        }

        public async Task<bool> Guardar(Servicios servicio)
        {
            try
            {
                servicio.Activo = true;
                return await _manager.Guardar(servicio);
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "Servicio", "Guardar");
                throw ex;
            }
        }
    }
}
