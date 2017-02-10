using Microsoft.AspNetCore.Hosting;

namespace ControllerDiscoveryIssue
{
    public class Program
    {
        public static void Main()
        {
            var host = new WebHostBuilder()
                .UseUrls("http://*:9000")
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
