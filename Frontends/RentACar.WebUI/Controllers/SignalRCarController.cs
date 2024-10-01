using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class SignalRCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
