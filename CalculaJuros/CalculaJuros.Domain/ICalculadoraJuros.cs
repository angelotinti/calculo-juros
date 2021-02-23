namespace CalculaJuros.Domain
{
    public interface ICalculadoraJuros
    {
        CalculoResult CalcularJurosCompostos(decimal valorInicial, int tempoEmMeses, float juros);
    }
}
