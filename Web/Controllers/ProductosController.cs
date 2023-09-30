using Data.Base;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Productos()
        {
            return View();
        }

        public IActionResult ProductosAddPartial(Productos productos)
        {
            return PartialView("~/Views/Productos/Partial/ProductosAddPartial.cshtml");
        }

        public IActionResult GuardarProducto(Productos producto)
        {
            var baseApi = new BaseApi(_httpClientFactory);

            if(producto.Imagen_Archivo != null && producto.Imagen_Archivo.Length>0) 
            { 
                using(var ms= new MemoryStream())
                {
                    producto.Imagen_Archivo.CopyTo(ms);
                    var imagenBytes = ms.ToArray();
                    producto.Imagen = Convert.ToBase64String(imagenBytes);
                }
                producto.Imagen_Archivo = null;
            }

            var productos = baseApi.PostToAPI("Productos/GuardarProducto", producto, "");
            return View("~/Views/Productos/productos.cshtml");

        }
    }
}
