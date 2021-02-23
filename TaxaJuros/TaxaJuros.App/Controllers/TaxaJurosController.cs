using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxaJuros.Controllers
{
    [Route("api/taxa-juros")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        // GET: api/<TaxaJuros>
        [HttpGet]
        public float Get()
        {
            return 0.01f;
        }
    }
}
