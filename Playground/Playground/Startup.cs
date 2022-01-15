using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground
{
    public class Startup  // setting과 관련됨
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // 각종 서비스 추가 (DI) 영업 시작! -> DI : Dependency Injection
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // DI 서비스란? SRP (single Responsilblity Principle)
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // 얘는 HTTP 요청이 왔을때, 앱이 어떻게 응답하는지 일련의 과정들을 나타낸다고 보면 됨
        // 1) ISS, Apache 등에 HTTP 요청
        // 2) ASP.NET Core 서버(Kestrel) 전달
        // 3) 미들웨어 적용
        // 4) Controller로 전달
        // 5) COntroller에서 처리하고 Veiw로 전달, Controller에서 View로 아무것도 넘겨주지 않으면 동적이 아닌, 정적인 페이지가 될 것임

        // 미들웨어 : HTTP request / response를 처리하는 중간 부품이라고 생각하면 됨

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            // CSS, JavaScript 등에서 이미지 요청 받을 때 처리하는 애
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // 라우팅 패턴 설정
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
