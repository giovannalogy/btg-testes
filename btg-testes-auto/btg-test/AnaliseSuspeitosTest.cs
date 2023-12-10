using System;
using btg_testes_auto;
using Xunit;

namespace btg_test
{
    public class AnaliseSuspeitosTest
    {
        [Theory]
        [InlineData(true, true, true, true, true, "Assassino")]
        [InlineData(true, false, true, false, true, "Suspeita")]
        [InlineData(true, true, false, false, true, "Cúmplice")]
        [InlineData(false, false, false, false, false, "Inocente")]
        public void TesteExecutarQuestionarioSuspeito(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima, string resultadoEsperado)
        {
            // Arrange
            AnaliseSuspeitos analiseSuspeitos = new AnaliseSuspeitos();

            // Act
            string resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
