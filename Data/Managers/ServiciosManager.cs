using Data.Base;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Managers
{
    public class ServiciosManager : BaseManager<Servicios>
    {
        public override Task<List<Servicios>> Buscar()
        {
            throw new NotImplementedException();
        }

        public override async Task<List<Servicios>> BuscarLista()
        {
            var respuesta = contextoSingleton.Servicios.FromSqlRaw("ObtenerServicios").ToList();
            return respuesta;
        }

        public override async Task<bool> Eliminar(Servicios modelo)
        {
            var resultado = contextoSingleton.Database.ExecuteSqlRaw($"EliminarServicio {modelo.Id}");
            return Convert.ToBoolean(resultado);
        }

        public async Task<bool> Guardar(Servicios modelo)
        {
            var resultado = contextoSingleton.Database.ExecuteSqlRaw($"GuardarServicio {modelo.Id}, {modelo.Nombre}, {modelo.Activo}");
            return Convert.ToBoolean(resultado);
        }
    }
}
