using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke(string v)
        {

            return View();
        }
    }
}
