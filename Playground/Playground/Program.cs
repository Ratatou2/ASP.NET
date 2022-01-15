using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Progarm과 startup 두개로 세팅이 나뉘어져 있는 이유?
// program은 거시적인 설정(Http 서버, IIS 사용 여부등, 한번 설저앟면 거의 바뀌지 않음)
// startup은 세부적인 설정(미들웨어 설정, Depencdency Injectoin 등, 필요에 따라 추가 삭제 진행)

namespace Playground
{
    public class Program  // setting과 관련됨
    {
        // 3) !Host를 만든다
        // 4) 구동(Run) < 이때부터 Listen을 시작함
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // 1) 각종 옵션 설정을 세팅
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // 2) startup 클래스 지정
                    webBuilder.UseStartup<Startup>();
                });
    }
}
