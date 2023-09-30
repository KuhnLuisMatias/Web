using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ServiciosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
