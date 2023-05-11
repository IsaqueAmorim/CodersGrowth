using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult ParaHome()
        {
            var arquivo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","webapp" ,"index.html");
            return PhysicalFile(arquivo,"text/html");
        }
    }
}
