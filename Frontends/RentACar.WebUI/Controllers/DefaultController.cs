﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NuGet.Common;
using RentACar.Dto.LocationDtos;
using System.Net.Http.Headers;

namespace RentACar.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;
		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            // Call the API to get locations
            var responseMessage = await client.GetAsync("https://localhost:7055/api/Locations");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

                // Create the SelectListItems from the locations
                List<SelectListItem> values2 = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.LocationId.ToString()
                                                }).ToList();
                ViewBag.v = values2;
            }

            return View();
        }

        [HttpPost]
		public IActionResult Index(string book_pick_date, string book_off_date, string time_pick, string time_off, string locationID)
		{
			TempData["bookpickdate"] = book_pick_date;
			TempData["bookoffdate"] = book_off_date;
			TempData["timepick"] = time_pick;
			TempData["timeoff"] = time_off;
			TempData["locationID"] = locationID;
			return RedirectToAction("Index", "RentACarList");
		}
	}
}
