using System;
using btg_testes_auto;
using Moq;

namespace btg_test
{
	public class MotoristaTest
	{
        [Fact]
        public void EncontrarMotoristas_Suficientes()
        {
            // Arrange
            var mockPessoa1 = new Mock<Pessoa>();
            mockPessoa1.SetupGet(p => p.Idade).Returns(20);
            mockPessoa1.SetupGet(p => p.PossuiHabilitacaoB).Returns(true);

            var mockPessoa2 = new Mock<Pessoa>();
            mockPessoa2.SetupGet(p => p.Idade).Returns(25);
            mockPessoa2.SetupGet(p => p.PossuiHabilitacaoB).Returns(true);

            var mockPessoa3 = new Mock<Pessoa>();
            mockPessoa3.SetupGet(p => p.Idade).Returns(18);
            mockPessoa3.SetupGet(p => p.PossuiHabilitacaoB).Returns(false);

            var motorista = new Motorista();
            var pessoas = new List<Pessoa>
            {
                mockPessoa1.Object,
                mockPessoa2.Object,
                mockPessoa3.Object
            };

            // Act
            var resultado = motorista.EncontrarMotoristas(pessoas);

            // Assert
            Assert.Contains("Uhuu! Os motorista são", resultado);
        }

        [Fact]
        public void EncontrarMotoristas_Insuficientes()
        {
            // Arrange
            var mockPessoa1 = new Mock<Pessoa>();
            mockPessoa1.SetupGet(p => p.Idade).Returns(17);
            mockPessoa1.SetupGet(p => p.PossuiHabilitacaoB).Returns(false);

            var mockPessoa2 = new Mock<Pessoa>();
            mockPessoa2.SetupGet(p => p.Idade).Returns(22);
            mockPessoa2.SetupGet(p => p.PossuiHabilitacaoB).Returns(true);

            var motorista = new Motorista();
            var pessoas = new List<Pessoa>
            {
                mockPessoa1.Object,
                mockPessoa2.Object
            };

            // Assert
            Assert.Throws<Exception>(() => motorista.EncontrarMotoristas(pessoas));
        }
    }
}

