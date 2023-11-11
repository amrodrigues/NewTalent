using System;
using Xunit;
using NewTalent;

namespace TesteNewTalent
{
    public class UnitTest1
    {

        public Calculadora ConstruirClasse()
        {
            string data = "11/11/2023";
            Calculadora cal = new Calculadora(data);

            return cal;
        }


        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]

        public void TesteSomar(int val1 , int val2, int resultado)
        {
            Calculadora calc =ConstruirClasse();

            int resultadoCalculadora = calc.Somar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
         
         }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]

        public void TesteMultiplicar(int val1, int val2, int resultado)
        {
            Calculadora calc = ConstruirClasse();

            int resultadoCalculadora = calc.Multiplicar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);

        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]

        public void TesteDividr(int val1, int val2, int resultado)
        {
            Calculadora calc = ConstruirClasse();

            int resultadoCalculadora = calc.Dividir(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);

        }

        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(5, 5, 0)]

        public void TesteSubtrair(int val1, int val2, int resultado)
        {
            Calculadora calc = ConstruirClasse();

            int resultadoCalculadora = calc.Subtrair(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);

        }

        [Fact]

        public void TestarDivisaoporZero()
        {
            Calculadora calc = ConstruirClasse();

            Assert.Throws<DivideByZeroException>(
                ()=> calc.Dividir(3,0)
                );
        }


        [Fact]

        public void TestarHistorico()
        {
            Calculadora calc = ConstruirClasse();

            calc.Somar(2, 3);
            calc.Somar(3, 2);
            calc.Somar(6, 3);
            calc.Somar(3, 8);

            var lista = calc.Historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}
