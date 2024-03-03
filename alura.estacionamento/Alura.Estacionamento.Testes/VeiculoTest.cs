using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTest
    {
        [Fact (DisplayName = "M�todo Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            // Arrange
            var veiculo = new Veiculo();

            // Act
            veiculo.Acelerar(10);

            // Assert: Valida o resultado esperado
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "M�todo Frear")]
        public void TestaVeiculoFrear()
        {
            // Arrange
            var veiculo = new Veiculo();

            // Act
            veiculo.Frear(10);

            // Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste ainda n�o implementado")]
        public void ValidaNomeProprietario()
        {

        }
    }
}
