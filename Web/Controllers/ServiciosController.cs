﻿using Data.Base;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;
using System.Net.Http;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        //public ServiciosController(IHttpClientFactory httpClient) => _httpClient = httpClient;

        public ServiciosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Servicios()
        {
            return View();
        }

        public IActionResult ServiciosAddPartial([FromBody] Servicios servicios)
        {
            var serviciosViewModel = new ServiciosViewModel();

            if (servicios != null)
            {
                serviciosViewModel = servicios;
            }
            return PartialView("~/Views/Servicios/Partial/ServiciosAddPartial.cshtml", serviciosViewModel);
        }

        public IActionResult GuardarServicio(Servicios servicio)
        {
            var baseApi = new BaseApi(_httpClient);
            var servicios = baseApi.PostApi("Servicios/GuardarServicio", servicio, "");
            return View("~/Views/Servicios/Servicios.cshtml");
        }
        public IActionResult EliminarServicio([FromBody] Servicios servicio)
        {
            var baseApi = new BaseApi(_httpClient);
            var servicios = baseApi.PostApi("Servicios/EliminarServicio", servicio, "");
            return View("~/Views/Servicios/Servicios.cshtml");
        }
    }
}
