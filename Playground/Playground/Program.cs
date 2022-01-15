using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Progarm�� startup �ΰ��� ������ �������� �ִ� ����?
// program�� �Ž����� ����(Http ����, IIS ��� ���ε�, �ѹ� �����۸� ���� �ٲ��� ����)
// startup�� �������� ����(�̵���� ����, Depencdency Injectoin ��, �ʿ信 ���� �߰� ���� ����)

namespace Playground
{
    public class Program  // setting�� ���õ�
    {
        // 3) !Host�� �����
        // 4) ����(Run) < �̶����� Listen�� ������
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // 1) ���� �ɼ� ������ ����
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // 2) startup Ŭ���� ����
                    webBuilder.UseStartup<Startup>();
                });
    }
}
