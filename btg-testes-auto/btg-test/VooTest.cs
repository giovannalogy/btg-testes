using System;
using btg_testes_auto;

namespace btg_test
{
    public class VooTest
    {
        public class VooTests
        {
            [Fact]
            public void ProximoLivre_SemAssentosDisponiveis_DeveRetornarZero()
            {
                // Arrange
                DateTime dataHora = new DateTime(2023, 12, 1);
                Voo voo = new Voo("Boeing 737", "123", dataHora);

                // Act
                for (int i = 0; i < 100; i++)
                {
                    voo.OcupaAssento(i);
                }

                int proximoLivre = voo.ProximoLivre();

                // Assert
                Assert.Equal(0, proximoLivre);
            }

            [Fact]
            public void ProximoLivre_ComAssentosDisponiveis_DeveRetornarProximaPosicao()
            {
                // Arrange
                DateTime dataHora = new DateTime(2023, 12, 1);
                Voo voo = new Voo("Boeing 737", "123", dataHora);

                // Act
                int proximoLivre = voo.ProximoLivre();

                // Assert
                Assert.NotEqual(0, proximoLivre);
                Assert.True(voo.AssentoDisponivel(proximoLivre));
            }

            [Fact]
            public void OcupaAssento_AoOcuparAssento_DisponibilidadeDeveSerFalsa()
            {
                // Arrange
                DateTime dataHora = new DateTime(2023, 12, 1);
                Voo voo = new Voo("Boeing 737", "123", dataHora);

                // Act
                int proximoLivre = voo.ProximoLivre();
                bool ocupadoAntes = voo.AssentoDisponivel(proximoLivre);
                bool ocupou = voo.OcupaAssento(proximoLivre);
                bool ocupadoDepois = voo.AssentoDisponivel(proximoLivre);

                // Assert
                Assert.True(ocupadoAntes);
                Assert.True(ocupou);
                Assert.False(ocupadoDepois);
            }

            [Fact]
            public void QuantidadeVagasDisponiveis_ComAssentosOcupados_DeveRetornarZero()
            {
                // Arrange
                DateTime dataHora = new DateTime(2023, 12, 1);
                Voo voo = new Voo("Boeing 737", "123", dataHora);

                // Act
                for (int i = 0; i < 100; i++)
                {
                    voo.OcupaAssento(i);
                }

                int vagasDisponiveis = voo.QuantidadeVagasDisponivel();

                // Assert
                Assert.Equal(0, vagasDisponiveis);
            }

            [Fact]
            public void ExibeInformacoesVoo_DeveRetornarInformacoesCorretas()
            {
                // Arrange
                DateTime dataHora = new DateTime(2023, 12, 1);
                Voo voo = new Voo("Boeing 737", "123", dataHora);

                // Act
                string informacoes = voo.ExibeInformacoesVoo();

                // Assert
                Assert.Contains("Aeronave Boeing 737", informacoes);
                Assert.Contains("registrada sob voo de número 123", informacoes);
                Assert.Contains("para o dia e hora 01/12/2023", informacoes);
            }
        }
    }

}