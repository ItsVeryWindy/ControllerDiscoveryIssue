using ControllerDiscoveryIssue;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Net;
using System.Reflection;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void ShouldReturnHelloButWillReturnNotFound()
        {
            using (var server = new TestServer(new WebHostBuilder()
                            .UseStartup<Startup>()))
            {
                var client = server.CreateClient();

                var response = client.GetAsync("/myroute").Result;

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            }
        }

        [Test]
        public void ShouldReturnHello()
        {
            using (var server = new TestServer(new WebHostBuilder()
                            .UseStartup<Startup>()
                            .UseSetting(WebHostDefaults.ApplicationKey, Assembly.GetEntryAssembly().FullName)))
            {
                var client = server.CreateClient();

                var response = client.GetAsync("/myroute").Result;

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

                var content = response.Content.ReadAsStringAsync().Result;

                Assert.That(content, Is.EqualTo("hello"));
            }
        }
    }
}
