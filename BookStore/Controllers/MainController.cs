using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
