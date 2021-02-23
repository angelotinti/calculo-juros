using System;

namespace CalculaJuros.Domain
{
    public class CalculadoraJuros : ICalculadoraJuros
    {
        public CalculoResult CalcularJurosCompostos(decimal valorInicial, int tempoEmMeses, float juros)
        {
            if (valorInicial <= 0)
                return CalculoResult.IsError("Valor inicial deve ser maior que zero.");

            if (juros <= 0)
                return CalculoResult.IsError("Juros deve ser maior que zero.");

            if (tempoEmMeses <= 0)
                return CalculoResult.IsError("Tempo em meses deve ser maior que zero.");

            var valorFinal = valorInicial * (decimal)Math.Pow((double)(1 + (double)juros), tempoEmMeses);

            return CalculoResult.IsSuccess(Math.Truncate(valorFinal * 100) / 100);
        }
    }
}
