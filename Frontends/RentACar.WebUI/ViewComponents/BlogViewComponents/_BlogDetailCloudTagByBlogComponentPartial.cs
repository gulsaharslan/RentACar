﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACar.Dto.BlogDtos;
using RentACar.Dto.TagCloudDtos;

namespace RentACar.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCloudTagByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BlogDetailCloudTagByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogid=id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7055/api/TagClouds/GetTagClodByBlogId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetByBlogIdTagCloudDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
