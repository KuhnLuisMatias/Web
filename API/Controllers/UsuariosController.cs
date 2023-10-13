using API.Services;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly UsuariosServices _services;
        public UsuariosController()
        {
            _services = new UsuariosServices();
        }

        [HttpGet]
        [Route("BuscarUsuarios")]
        public async Task<List<Usuarios>> BuscarUsuarios()
        {
            return await _services.BuscarLista();
        }

        [HttpPost]
        [Route("GuardarUsuario")]
        public async Task<List<Usuarios>> GuardarUsuario(Usuarios usuario)
        {
            return await _services.Guardar(usuario);
        }

        [HttpPost]
        [Route("EliminarUsuario")]
        public async Task<bool> EliminarUsuario(Usuarios usuario)
        {
            return await _services.Eliminar(usuario);
        }
    }
}
