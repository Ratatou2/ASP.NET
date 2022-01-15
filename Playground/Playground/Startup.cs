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
    public class Startup  // setting�� ���õ�
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // ���� ���� �߰� (DI) ���� ����! -> DI : Dependency Injection
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // DI ���񽺶�? SRP (single Responsilblity Principle)
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // ��� HTTP ��û�� ������, ���� ��� �����ϴ��� �Ϸ��� �������� ��Ÿ���ٰ� ���� ��
        // 1) ISS, Apache � HTTP ��û
        // 2) ASP.NET Core ����(Kestrel) ����
        // 3) �̵���� ����
        // 4) Controller�� ����
        // 5) COntroller���� ó���ϰ� Veiw�� ����, Controller���� View�� �ƹ��͵� �Ѱ����� ������ ������ �ƴ�, ������ �������� �� ����

        // �̵���� : HTTP request / response�� ó���ϴ� �߰� ��ǰ�̶�� �����ϸ� ��

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

            // CSS, JavaScript ��� �̹��� ��û ���� �� ó���ϴ� ��
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // ����� ���� ����
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
