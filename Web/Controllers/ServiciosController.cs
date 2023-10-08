using Data.Base;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiciosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Servicios()
        {
            return View();
        }

        public IActionResult ServiciosAddPartial([FromBody] Servicios servicios)
        {
            var serviciosViewModel = new ServiciosViewModel();

            if (servicios != null)
                serviciosViewModel = servicios;

            return PartialView("~/Views/Servicios/Partial/ServiciosAddPartial.cshtml", serviciosViewModel);
        }

        public IActionResult GuardarServicio(Servicios servicio)
        {
            var baseApi = new BaseApi(_httpClientFactory);

            var servicios = baseApi.PostToAPI("Servicios/GuardarServicio", servicio, "");
            return View("~/Views/Servicios/servicios.cshtml");
        }

        public IActionResult EliminarServicio([FromBody] Servicios servicio)
        {
            var baseApi = new BaseApi(_httpClientFactory);
            var servicios = baseApi.PostToAPI("Servicios/EliminarServicio", servicio, "");
            return View("~/Views/Servicios/servicios.cshtml");
        }
    }
}
