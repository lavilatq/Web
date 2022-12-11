using Data.Base;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Web.ViewModels;

namespace Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public RolesController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

		[Authorize]
		public IActionResult Roles()
        {
            return View();
        }

        public IActionResult RolesAddPartial([FromBody] Roles Roles)
        {
            var RolesViewModel = new RolesViewModel();

            if (Roles != null)
            {
                RolesViewModel = Roles;
            }
            return PartialView("~/Views/Roles/Partial/RolesAddPartial.cshtml", RolesViewModel);
        }

        public IActionResult GuardarRol(Roles Rol)
        {
            var baseApi = new BaseApi(_httpClient);

            var Roles = baseApi.PostToApi("Roles/GuardarRol", Rol, "");
            return View("~/Views/Roles/Roles.cshtml");
        }
        public IActionResult EliminarRol([FromBody] Roles Rol)
        {
            var baseApi = new BaseApi(_httpClient);
            var Roles = baseApi.PostToApi("Roles/EliminarRol", Rol, "");
            return View("~/Views/Roles/Roles.cshtml");
        }
    }
}
