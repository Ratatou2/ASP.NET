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


            return View();
        }

        [HttpPost]
        public ActionResult Test(Test model)
        {
            string[] userInfo = new string[10];
            

            return View();
        }



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
