using Data.Base;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RolesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Authorize]
        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult RolesAddPartial([FromBody] Roles roles)
        {
            var rolesViewModel = new RolesViewModel();

            if (roles != null)
                rolesViewModel = roles;

            return PartialView("~/Views/Roles/Partial/RolesAddPartial.cshtml", rolesViewModel);
        }

        public IActionResult GuardarRol(Roles rol)
        {
            var baseApi = new BaseApi(_httpClientFactory);
            
            var roles = baseApi.PostToAPI("Roles/GuardarRol", rol, "");
            return View("~/Views/Roles/roles.cshtml");
        }

        public IActionResult EliminarRol([FromBody] Roles rol)
        {
            var baseApi = new BaseApi(_httpClientFactory);
            var roles = baseApi.PostToAPI("Roles/EliminarRol", rol, "");
            return View("~/Views/Roles/roles.cshtml");
        }
    }
}
