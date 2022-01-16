using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Playground.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Playground.Controllers
{
    public class LoginController : Controller
    {
        private HttpContext _context;

        public LoginController(IHttpContextAccessor accessor)
        {
            _context = accessor.HttpContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (model.userID == "abcdef" && model.userPW == "1234")
            {
                var identity = new ClaimsIdentity(claims: new[] {
                    new Claim(type: ClaimTypes.Name, value: model.userID),
                    new Claim(type: ClaimTypes.Role, value: "admin"),
                    new Claim(type: ClaimTypes.UserData, value: "관리자")
                }, authenticationType: CookieAuthenticationDefaults.AuthenticationScheme);

                await _context.SignInAsync(scheme: CookieAuthenticationDefaults.AuthenticationScheme, principal: new ClaimsPrincipal(identity: identity), properties: new AuthenticationProperties() { AllowRefresh = true, IsPersistent = true, ExpiresUtc = DateTime.UtcNow.AddMinutes(1) });

                TempData["result"] = "로그인에 성공하였습니다.";
            }
            else
            {
                TempData["result"] = "로그인에 실패하였습니다.";
            }

            return View("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await _context.SignOutAsync(scheme: CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }




        public IActionResult Privacy()
        {
            // ViewData를 이용하면 뷰에 동적으로 데이터를 넘길 수 있다
            ViewData["Message"] = "이렇게 하면 뷰에 데이터를 넘길 수 있따";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
