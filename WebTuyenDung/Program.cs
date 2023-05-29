using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebTuyenDung
{
    public class Program
    {
        public static void Main(string[] args)
        {
             CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(webBuilder =>
                       {
                           webBuilder
                               .UseStartup<Startup>()
                               .UseKestrel(options =>
                               {
                                   options.Limits.MaxRequestBodySize = 256 * 1024 * 1024;
                               });
                       });
        }
    }
}
