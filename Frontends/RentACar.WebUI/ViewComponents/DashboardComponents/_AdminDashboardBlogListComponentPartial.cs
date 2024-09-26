using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.BlogDtos;

namespace RentACar.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardBlogListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardBlogListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7055/api/Blogs/GetLast3BlogsWitAuthorsList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
