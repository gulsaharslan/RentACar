﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using RentACar.Dto.LoginDtos;
using RentACar.WebUI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace RentACar.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7055/api/Logins", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();

                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("accessToken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var autProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), autProps);

                        // Kullanıcının rolünü kontrol ediyoruz
                        if (claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "Admin"))
                        {
                            return RedirectToAction("Index", "AdminDashboard", new { area = "Admin" });
                        }

                        // Eğer admin değilse default sayfasına yönlendirme
                        return RedirectToAction("Index", "Default");
                    }
                }
            }

            // Eğer giriş başarısızsa aynı sayfayı geri döndürür
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Kullanıcının oturumunu sonlandırma
            await HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);

            // Çıkış yaptıktan sonra login sayfasına yönlendirme
            return RedirectToAction("Index", "Login");
        }
    }
}
   

