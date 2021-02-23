using CalculaJuros.Domain;

namespace CalculaJuros.App.Services
{
    public interface ICalculaJurosService
    {
        CalculoResult CalcularJurosCompostos(decimal valorInicial, int tempoEmMeses);
    }
}
