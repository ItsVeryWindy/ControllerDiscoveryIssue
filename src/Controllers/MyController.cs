using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class MyController : Controller
    {
        [HttpGet("/myroute")]
        public ContentResult Get()
        {
            return new ContentResult
            {
                Content = "hello"
            };
        }
    }
}
