using CalculaJuros.Domain;
using FluentAssertions;
using Xunit;

namespace CalculaJuros.Tests.Domain
{
    public class CalculadoraJurosTests
    {
        private readonly ICalculadoraJuros _calculadoraJuros;

        public CalculadoraJurosTests()
        {
            _calculadoraJuros = new CalculadoraJuros();
        }

        [Fact]
        public void CalcularJurosCompostos_com_valorInicial_zerado()
        {
            decimal valorInicialZero = 0;

            var resultado = _calculadoraJuros.CalcularJurosCompostos(valorInicialZero, 0, 0);

            resultado.Should().NotBeNull();
            resultado.Success.Should().BeFalse();
            resultado.Message.Should().Be("Valor inicial deve ser maior que zero.");
        }

        [Fact]
        public void CalcularJurosCompostos_com_valorInicial_negativo()
        {
            decimal valorInicialNegativo = -1;

            var resultado = _calculadoraJuros.CalcularJurosCompostos(valorInicialNegativo, 0, 0);

            resultado.Should().NotBeNull();
            resultado.Success.Should().BeFalse();
            resultado.Message.Should().Be("Valor inicial deve ser maior que zero.");
        }

        [Fact]
        public void CalcularJurosCompostos_com_juros_zerado()
        {
            decimal valorInicialValido = 1;
            float jurosZero = 0;

            var resultado = _calculadoraJuros.CalcularJurosCompostos(valorInicialValido, 0, jurosZero);

            resultado.Should().NotBeNull();
            resultado.Success.Should().BeFalse();
            resultado.Message.Should().Be("Juros deve ser maior que zero.");
        }

        [Fact]
        public void CalcularJurosCompostos_com_juros_negativo()
        {
            decimal valorInicialValido = 1;
            float jurosNegativo = -1;

            var resultado = _calculadoraJuros.CalcularJurosCompostos(valorInicialValido, 0, jurosNegativo);

            resultado.Should().NotBeNull();
            resultado.Success.Should().BeFalse();
            resultado.Message.Should().Be("Juros deve ser maior que zero.");
        }

        [Fact]
        public void CalcularJurosCompostos_com_juros_e_valorInicial_maior_que_zero_e_tempoEmMeses_zero()
        {
            decimal valorInicialValido = 1;
            float jurosValido = 1;
            int tempoEmMesesZero = 0;

            var resultado = _calculadoraJuros.CalcularJurosCompostos(valorInicialValido, tempoEmMesesZero, jurosValido);

            resultado.Should().NotBeNull();
            resultado.Success.Should().BeFalse();
            resultado.Message.Should().Be("Tempo em meses deve ser maior que zero.");
        }

        [Fact]
        public void CalcularJurosCompostos_com_juros_e_valorInicial_maior_que_zero_e_tempoEmMeses_negativo()
        {
            decimal valorInicialValido = 1;
            float jurosValido = 1;
            int tempoEmMesesNegativo = -1;

            var resultado = _calculadoraJuros.CalcularJurosCompostos(valorInicialValido, tempoEmMesesNegativo, jurosValido);

            resultado.Should().NotBeNull();
            resultado.Success.Should().BeFalse();
            resultado.Message.Should().Be("Tempo em meses deve ser maior que zero.");
        }

        [Theory]
        [InlineData(1, 0.01, 1, 1)]
        [InlineData(10, 0.02, 5, 11.04)]
        [InlineData(100, 0.03, 10, 134.39)]
        [InlineData(237, 0.01, 12, 267.05)]
        public void CalcularJurosCompostos_com_juros_valorInicial_e_tempoEmMeses_maiores_que_zero(
            decimal valorInicial, float juros, int tempoEmMeses, decimal valorFinal)
        {
            var resultado = _calculadoraJuros.CalcularJurosCompostos(valorInicial, tempoEmMeses, juros);

            resultado.Should().NotBeNull();
            resultado.Success.Should().BeTrue();
            resultado.Value.Should().Be(valorFinal);
        }
    }
}
