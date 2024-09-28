using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Books()
        {
            return View();
        }
    }
}
