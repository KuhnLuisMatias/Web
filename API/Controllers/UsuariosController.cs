using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
