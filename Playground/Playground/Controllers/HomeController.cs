using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Playground.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Test()
        {

            //Response.Write("<script>alert('메세지박스')</script>");

            return View();
        }


        public ActionResult LoginSuccess()
        {
            return View();
        }


        [HttpPost]
        //[Authorize]
        public ActionResult Test(Test model)
        {
            if (true == ModelState.IsValid)
            {
                if (model._Id == "Test123" & model._password == "qwer1234")
                {
                    return Redirect("LoginSuccess");
                }
                else
                {
                    return Redirect("Error");
                }
            }

            

            return View();
        }

        //public ActionResult Error()
        //{

        //    return Redirect("index");
        //}





        //// POST: /Account/Login
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> LogIn(LoginViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var account = await _accountService.LogInAsync(model.Email, model.Password);

        //    if (account != null)
        //    {
        //        var claims = BuildClaims(account);

        //        var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity));

        //        return RedirectToAction("Index", "Home");
        //    }

        //    ModelState.AddModelError(string.Empty, _localizer["사용자 이메일 혹은 비밀번호가 올바르지 않습니다."]);
        //    return View(model);
        //}





        public IActionResult Student()
        // 얘는 Student.cshtml(레이저 파일)을 Display하는 역할
        {
            return View();
        }

        [HttpPost]
        public IActionResult Student(Student model)
        // 얘는 HttpPost를 붙임으로써 HTML 뷰에서 넘어오는 값을 받는 역할을 함
        // MVC가 자동으로 입력값들을 Student의 매개변수(model들로)로 변환해줌
        {
            return View();
        }



/*        [HttpPost]
        public IActionResult Student([Bind("Name, Age")] Student model)
        // 바인드 에트리뷰트 적용(ex. 이름과 나이만 받고 싶어요!)
        {
            return View();
        }*/


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
