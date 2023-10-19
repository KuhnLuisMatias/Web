using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ChatController : Controller
    {
        [Authorize]
        public IActionResult Chat(int idChat)
        {
            return View(idChat);
        }
    }
}
