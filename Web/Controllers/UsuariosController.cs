using Data.Base;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Web.ViewModels;

namespace Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UsuariosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //[Authorize(Roles ="Administrador,Usuario,Mantenimiento2,SQL")]
        public IActionResult Usuarios()
        {
            return View();
        }

        public async Task<IActionResult> UsuariosAddPartial([FromBody] Usuarios usuarios)
        {
            var baseApi = new BaseApi(_httpClientFactory);
            var roles = await baseApi.GetToApi("Roles/BuscarRoles", "");
            var usuariosViewModel = new UsuariosViewModel();
            var resultadoRoles = roles as OkObjectResult;

            if (usuarios != null)
                usuariosViewModel = usuarios;

            if (resultadoRoles != null)
            {
                var listaRoles = JsonConvert.DeserializeObject<List<Roles>>(resultadoRoles.Value.ToString());
                var listaItemsRoles = new List<SelectListItem>();
                foreach (var item in listaRoles)
                    listaItemsRoles.Add(new SelectListItem { Text = item.Nombre, Value = item.Id.ToString() });
                usuariosViewModel.Lista_Roles = listaItemsRoles;
            }

            return PartialView("~/Views/Usuarios/Partial/UsuariosAddPartial.cshtml", usuariosViewModel);
        }

        public IActionResult GuardarUsuario(Usuarios usuario)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClientFactory);

            var usuarioApi = baseApi.PostToAPI("Usuarios/GuardarUsuario", usuario, token);
            return View("~/Views/Usuarios/usuarios.cshtml");
        }

        public IActionResult EliminarUsuario([FromBody] Usuarios usuario)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClientFactory);

            var usuarioApi = baseApi.PostToAPI("Usuarios/EliminarUsuario", usuario, token);
            return View("~/Views/Usuarios/usuarios.cshtml");
        }
    }
}
