using Microsoft.AspNetCore.Mvc;

namespace CalculaJuros.App.Controllers
{
    [Route("api/show-me-the-code")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly string ShowMeTheCode = "https://github.com/angelotinti/calculo-juros";

        [HttpGet]
        public string Get()
        {
            return ShowMeTheCode;
        }
    }
}
