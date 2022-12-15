using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebStoreMVC.Models;

namespace WebStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Home/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("[controller]/get-simple-response")]
        [Route("get-simple-response")]
        public IActionResult SimpleResponse()
        {
            return Ok(new Customer { FirstName = "John", LastName = "Doe" });
        }
        [Route("Home/Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult JsonTest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> JsonTestResponse([FromBody] Document doc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(doc);
        }
    }
}