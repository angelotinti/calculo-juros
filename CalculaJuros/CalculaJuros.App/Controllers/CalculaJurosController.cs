using CalculaJuros.App.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalculaJuros.App.Controllers
{
    [Route("api/calcula-juros")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosService _calculaJurosService;

        public CalculaJurosController(ICalculaJurosService calculaJurosService)
        {
            _calculaJurosService = calculaJurosService;
        }

        // GET: api/calcula-juros
        [HttpGet]
        public ActionResult<decimal> Get(decimal? valorInicial, int? tempoEmMeses)
        {
            if (!valorInicial.HasValue)
                return BadRequest("Valor inicial deve ser informado.");

            if (!tempoEmMeses.HasValue)
                return BadRequest("Tempo em meses deve ser informado.");

            var resultado = _calculaJurosService.CalcularJurosCompostos(valorInicial.Value, tempoEmMeses.Value);

            if (!resultado.Success)
                return BadRequest(resultado.Message);

            return resultado.Value;
        }
    }
}
