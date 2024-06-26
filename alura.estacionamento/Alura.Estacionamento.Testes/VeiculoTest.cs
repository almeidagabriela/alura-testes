using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTest : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTest(ITestOutputHelper _saidaConsoleTeste) 
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            // Act
            veiculo.Acelerar(10);

            // Assert: Valida o resultado esperado
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            // Act
            veiculo.Frear(10);

            // Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste ainda n�o implementado")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            // Arrange
            veiculo.Proprietario = "Gabriela Almeida";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Amarelo";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            // Act
            string dados = veiculo.ToString();

            // Assert
            Assert.Contains("Ficha do Ve�culo:", dados);
        }

        [Fact]
        public void NomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            // Arrange
            string nomeProprietario = "Ab";

            // Act + Assert
            Assert.Throws<System.FormatException>(
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void MensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            // Arrange
            string placa = "ASDF8888";

            // Act
            var mensagem = Assert.Throws<System.FormatException>(
                    () => new Veiculo().Placa = placa
                );

            // Assert
            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
