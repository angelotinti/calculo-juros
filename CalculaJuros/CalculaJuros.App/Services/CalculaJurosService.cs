using CalculaJuros.App.Integrations;
using CalculaJuros.Domain;

namespace CalculaJuros.App.Services
{
    public class CalculaJurosService : ICalculaJurosService
    {
        private readonly ITaxaJurosIntegrator _taxaJurosIntegrator;
        private readonly ICalculadoraJuros _calculadoraJuros;

        public CalculaJurosService(ITaxaJurosIntegrator taxaJurosIntegrator, ICalculadoraJuros calculadoraJuros)
        {
            _taxaJurosIntegrator = taxaJurosIntegrator;
            _calculadoraJuros = calculadoraJuros;
        }

        public CalculoResult CalcularJurosCompostos(decimal valorInicial, int tempoEmMeses)
        {
            var taxaJurosRead = _taxaJurosIntegrator.ReadTaxaJuros();
            if (taxaJurosRead.Success)
            {
                return _calculadoraJuros.CalcularJurosCompostos(valorInicial, tempoEmMeses, taxaJurosRead.Value.Value);
            }
            return CalculoResult.IsError(taxaJurosRead.Message);
        }
    }
}
