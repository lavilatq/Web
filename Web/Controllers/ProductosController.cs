using Data.Base;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;
using System.Net.Http;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        //public ProductosController(IHttpClientFactory httpClient) => _httpClient = httpClient;

        public ProductosController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Productos()
        {
            return View();
        }

        public IActionResult ProductosAddPartial([FromBody]Productos productos)
        {
            var productosViewModel = new ProductosViewModel();

            if(productos != null)
            {
                productosViewModel = productos;
            }
            return PartialView("~/Views/Productos/Partial/ProductosAddPartial.cshtml", productosViewModel);
        }

        public IActionResult GuardarProducto(Productos producto)
        {
            var baseApi = new BaseApi(_httpClient);

            if (producto.Imagen_archivo is not null && producto.Imagen_archivo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    
                    producto.Imagen_archivo.CopyTo(ms);
                    var imagenBytes = ms.ToArray();
                    producto.Imagen = Convert.ToBase64String(imagenBytes);
                }
            }
            producto.Imagen_archivo = null;
            var productos = baseApi.PostApi("Productos/GuardarProducto", producto, "");
            return View("~/Views/Productos/Productos.cshtml");
        }
        public IActionResult EliminarProducto([FromBody]Productos producto)
        {
            var baseApi = new BaseApi(_httpClient);
            var productos = baseApi.PostApi("Productos/EliminarProducto", producto, "");
            return View("~/Views/Productos/Productos.cshtml");
        }
    }
}
