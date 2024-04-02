using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTest : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTest(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            // Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = "Gabriela Almeida";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Amarelo";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Gabriel Almeida", "ASD-1498", "Preto", "Gol")]
        [InlineData("Hilda Almeida", "EVE-1797", "Amarelo", "Classic")]
        [InlineData("Franchilly Santos", "DAL-1872", "Prata", "Opala")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo= modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Gabriel Almeida", "ASD-1498", "Preto", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            // Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            // Assert
            Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
        }

        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            // Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = "Gabriela Almeida";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Amarelo";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Gabriela Almeida";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Preto"; // Alteração
            veiculoAlterado.Modelo = "Fusca";
            veiculoAlterado.Placa = "asd-9999";

            // Act
            var alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            // Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
