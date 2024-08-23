using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.BlogDtos;

namespace RentACar.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailRecentBlogComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BlogDetailRecentBlogComponentPartial(IHttpClientFactory httpClientFactory)
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
                var values = JsonConvert.DeserializeObject<List<ResultLast3BlogsWithAuthors>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
