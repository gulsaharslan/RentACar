using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.CarDtos;
using RentACar.Dto.FeatureDtos;
using System.Text;

namespace RentACar.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminFeature")]
    public class AdminFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7055/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateFeature")]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7055/api/Features", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminFeature", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveFeature/{id}")]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7055/api/Features/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminFeature", new { area = "Admin" });
            }
            return View();
        }
    }
}
