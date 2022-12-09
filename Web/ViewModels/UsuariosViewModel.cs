using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.ViewModels
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Email { get; set; }
        public int Id_Rol { get; set; }
        public string Clave { get; set; }
        public int? Codigo { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<SelectListItem>Lista_Roles { get; set; }

        public static implicit operator UsuariosViewModel(Usuarios v)
        {
            var usuarioViewModel = new UsuariosViewModel();
            usuarioViewModel.Id = v.Id;
            usuarioViewModel.Nombre = v.Nombre;
            usuarioViewModel.Apellido = v.Apellido;
            usuarioViewModel.Fecha_Nacimiento = v.Fecha_Nacimiento;
            usuarioViewModel.Clave = v.Clave;
            usuarioViewModel.Id_Rol = v.Id_Rol;
            usuarioViewModel.Activo = v.Activo;
            usuarioViewModel.Email = v.Email;
            usuarioViewModel.Codigo = v.Codigo;
            return usuarioViewModel;
        }
    }
}