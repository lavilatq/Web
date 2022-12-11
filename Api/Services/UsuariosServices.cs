using Api.Interfaces;
using Commons.Helpers;
using Data.Entities;
using Data.Managers;

namespace Api.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly UsuariosManager _manager;

        public UsuariosServices()
        {
            _manager = new UsuariosManager();
        }
        public async Task<List<Usuarios>> BuscarLista()
        {
            try
            {
                return await _manager.BuscarLista();
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "Usuario", "BuscarLista");
                throw ex;
            }
        }

        public async Task<bool> Eliminar(Usuarios usuario)
        {
            usuario.Activo = false;
            return await _manager.Eliminar(usuario);
        }

        public async Task<bool> Guardar(Usuarios usuario)
        {
            try
            {
                var usuarioRepetido = _manager.BuscarUsuarioRepetido(usuario);

                if(usuarioRepetido.Result != null)
                {
                    return false;

                }
                usuario.Activo = true;
                usuario.Clave = EncryptHelper.Entriptar(usuario.Clave);
                return await _manager.Guardar(usuario, usuario.Id);
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "Usuario", "Guardar");
                throw ex;
            }
        }
    }
}

