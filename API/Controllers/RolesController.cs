using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
