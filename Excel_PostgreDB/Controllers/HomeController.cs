using Excel_PostgreDB.Domain.IService;
using Microsoft.AspNetCore.Mvc;

namespace Excel_PostgreDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IService _service;
        public HomeController(IService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult ImportExcelData()
        {
            _service.ImportExcelData();
            return Ok("Success");
        }
       
    }
}
