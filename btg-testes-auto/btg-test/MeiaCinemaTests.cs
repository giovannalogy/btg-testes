using System;
using btg_testes_auto;

namespace btg_test
{
	public class MeiaCinemaTests
	{
        [Theory]
        [InlineData(true, false, false, false, true)] // Estudante
        [InlineData(false, true, false, false, true)] // Doador de sangue
        [InlineData(false, false, true, true, true)] // Trabalhador da prefeitura com contrato
        [InlineData(false, false, true, false, false)] // Trabalhador da prefeitura sem contrato
        [InlineData(false, false, false, false, false)] // Sem direito à meia
        public void TestarVerificarMeiaCinema(bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura, bool resultadoEsperado)
        {
            // Arrange
            MeiaCinema meiaCinema = new MeiaCinema();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}

